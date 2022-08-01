using MediatR;
using ProjCampanhas.Application.Commands;
using ProjCampanhas.Application.Interfaces;
using ProjCampanhas.Application.Models;
using ProjCampanhas.Infra.Cache.MongoDB.Interfaces;
using ProjCampanhas.Infra.Cache.MongoDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjCampanhas.Application.Services
{
    public class CampanhaAppService : ICampanhaAppService
    {
        //atributo
        private readonly IMediator _mediator;
        private readonly ICampanhasPersistence _campanhasPersistence;

        //construtor para injeção de dependência
        public CampanhaAppService(IMediator mediator, ICampanhasPersistence campanhasPersistence)
        {
            _mediator = mediator;
            _campanhasPersistence = campanhasPersistence;
        }
        public async Task<CampanhaDto> Create(CampanhaCreateCommand command)
        {
              return await _mediator.Send(command);
        }

        public async Task<CampanhaDto> Update(CampanhaUpdateCommand command)
        {
             return await _mediator.Send(command);
        }

        public async Task<CampanhaDto> Delete(CampanhaDeleteCommand command)
        {
               return await _mediator.Send(command);
        }        

        public List<CampanhasModel> GetAll(int page, int limit)
        {
            return _campanhasPersistence.GetAll(page, limit);
        }

        public CampanhasModel GetById(Guid id)
        {
            return _campanhasPersistence.GetById(id);
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
