using ProjCampanhas.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjCampanhas.Application.Models
{
    /// <summary>
    /// Classe de modelo de transferência de dados para campanha
    /// </summary>
    public class CampanhaDto
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? Codigo { get; set; }
        public string? Descricao { get; set; }
        public TipoDeCampanha TipoDeCampanha { get; set; }
    }
}
