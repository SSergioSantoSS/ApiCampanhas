using AutoMapper;
using MediatR;
using ProjCampanhas.Application.Notifications;
using ProjCampanhas.Infra.Cache.MongoDB.Interfaces;
using ProjCampanhas.Infra.Cache.MongoDB.Models;
using ProjCampanhas.Infra.Cache.MongoDB.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjCampanhas.Application.NotificationHandlers
{
    /// <summary>
    /// Classe para capturar notificações da entidade Campanha(CREATED, UPDATED e DELETED)
    /// </summary>
    public class CampanhaNotificationHandler : INotificationHandler<CampanhaNotification>
    {
        //atributos
        private readonly ICampanhasPersistence _campanhasPersistence;
        private readonly IMapper _mapper;

        //construtor para injeção de dependência dos atributos
        public CampanhaNotificationHandler(ICampanhasPersistence campanhasPersistence, IMapper mapper)
        {
            _campanhasPersistence = campanhasPersistence;
            _mapper = mapper;
        }      

        public Task Handle(CampanhaNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                var model = _mapper.Map<CampanhasModel>(notification.Campanha);

                switch (notification.Action)
                {
                    case ActionNotification.Created:
                        _campanhasPersistence.Create(model);
                        break;

                    case ActionNotification.Updated:
                        _campanhasPersistence.Update(model);
                        break;

                    case ActionNotification.Deleted:
                        _campanhasPersistence.Delete(model);
                        break;
                }
            });
        }
    }

}
