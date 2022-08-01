using MediatR;
using ProjCampanhas.Application.Models;
using ProjCampanhas.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjCampanhas.Application.Commands
{
    /// <summary>
    /// Dados do comando de cadastro de Campanhas
    /// </summary>
    public class CampanhaCreateCommand : IRequest<CampanhaDto>
    {
        public string? Nome { get; set; }
        public string Codigo { get; set; }
        public DateTime? PeriodoInicio { get; set; }
        public DateTime? PeriodoFim { get; set; }
        public decimal? ValordoInvestimento { get; set; }
        public string? Descricao { get; set; }
        public int? QntHoras { get; set; }
        public TipoDeCampanha TipoDeCampanha { get; set; }


    }
}
