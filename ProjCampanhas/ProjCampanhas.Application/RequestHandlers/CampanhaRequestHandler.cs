using AutoMapper;
using FluentValidation;
using MediatR;
using ProjCampanhas.Application.Commands;
using ProjCampanhas.Application.Models;
using ProjCampanhas.Application.Notifications;
using ProjCampanhas.Domain.Entities;
using ProjCampanhas.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjCampanhas.Application.RequestHandlers
{
    /// <summary>
    /// Componente do MediatR para processamento dos Commands (CREATE, UPDATE e DELETE)
    /// </summary>
    public class CampanhaRequestHandler : IDisposable,
        IRequestHandler<CampanhaCreateCommand, CampanhaDto>,
        IRequestHandler<CampanhaUpdateCommand, CampanhaDto>,
        IRequestHandler<CampanhaDeleteCommand, CampanhaDto>
    {

        #region Injeção de dependência

        private readonly ICampanhaDomainService _campanhaDomainService;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CampanhaRequestHandler(ICampanhaDomainService campanhaDomainService, IMediator mediator, IMapper mapper)
        {
            _campanhaDomainService = campanhaDomainService;
            _mediator = mediator;
            _mapper = mapper;
        }

        #endregion

        public async Task<CampanhaDto> Handle(CampanhaCreateCommand request, CancellationToken cancellationToken)
        {
            #region Capturar os dados da Campanha

            var campanha = _mapper.Map<Campanha>(request);

            #endregion

            #region Executando a validação da entidade

            if (!campanha.Validate.IsValid)
            {
                throw new ValidationException(campanha.Validate.Errors);
            }
            #endregion

            await _campanhaDomainService.CreateAsync(campanha);

            
            var notification = new CampanhaNotification
            {
                Action =  ActionNotification.Created,
                Campanha = campanha

            };

            //Gerando uma Notificação (NOTIFICATION HANDLER)
            await _mediator.Publish(notification);

            //retornando o DTO com os dados da campanha
            return _mapper.Map<CampanhaDto>(campanha);

            
        }

        public async Task<CampanhaDto> Handle(CampanhaUpdateCommand request, CancellationToken cancellationToken)
        {
            #region Capturar os dados da Campanha

            var campanha = _mapper.Map<Campanha>(request);

            #endregion

            #region Executando a validação da entidade

            if (!campanha.Validate.IsValid)
            {
                throw new ValidationException(campanha.Validate.Errors);
            }
            #endregion

            await _campanhaDomainService.UpdateAsync(campanha);

            var notification = new CampanhaNotification
            {
                Action = ActionNotification.Updated,
                Campanha = campanha

            };

            //Gerando uma Notificação (NOTIFICATION HANDLER)
            await _mediator.Publish(notification);

            //retornando o DTO com os dados da campanha
            return _mapper.Map<CampanhaDto>(campanha);
        }

        public async Task<CampanhaDto> Handle(CampanhaDeleteCommand request, CancellationToken cancellationToken)
        {


            var campanha = await _campanhaDomainService.GetByIdAsync(request.Id);
            await _campanhaDomainService.DeleteAsync(campanha);

            var notification = new CampanhaNotification
            {
                Action = ActionNotification.Deleted,
                Campanha = campanha

            };

            //Gerando uma Notificação (NOTIFICATION HANDLER)
            await _mediator.Publish(notification);

            //retornando o DTO com os dados da campanha
            return _mapper.Map<CampanhaDto>(campanha);

        }

        public void Dispose()
        {
            _campanhaDomainService.Dispose();
        }
    }
}
