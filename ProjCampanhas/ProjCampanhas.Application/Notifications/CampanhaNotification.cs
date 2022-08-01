using MediatR;
using ProjCampanhas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjCampanhas.Application.Notifications
{
    /// <summary>
    /// Classe para armazenar as notificações relacionadas a Campanha
    /// </summary>
    public class CampanhaNotification : INotification
    {
        /// <summary>
        /// Define a ação que estamos recebendo para Campanha
        /// </summary>
        public ActionNotification Action { get; set; }

        /// <summary>
        /// Entidade com os dados da notificação
        /// </summary>
        public Campanha? Campanha { get; set; }
    }

}
