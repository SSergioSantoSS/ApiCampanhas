using MediatR;
using ProjCampanhas.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjCampanhas.Application.Commands
{
    /// <summary>
    /// Dados do comando de exclusão de Campanhas
    /// </summary>
    public class CampanhaDeleteCommand : IRequest<CampanhaDto>
    {
        public Guid Id { get; set; }
    }
}
