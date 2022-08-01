using ProjCampanhas.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjCampanhas.Infra.Cache.MongoDB.Models
{
    /// <summary>
    /// Modelo de dados do documento que será gravado no MongoDB
    /// </summary>
    public class CampanhasModel
    {
        public Guid Id { get; set; } 
        public string? Name { get; set; }    
        public string Codigo { get; set; }    
        public TipoDeCampanha TipoDeCampanha { get; set; }    
    }
}
