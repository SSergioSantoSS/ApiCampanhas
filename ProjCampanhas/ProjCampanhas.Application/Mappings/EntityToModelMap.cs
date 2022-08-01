using AutoMapper;
using ProjCampanhas.Application.Models;
using ProjCampanhas.Domain.Entities;
using ProjCampanhas.Infra.Cache.MongoDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjCampanhas.Application.Mappings
{
    // <summary>
    /// Classe de mapeamento de objetos ENTITY para => Model
    /// </summary>
    public class EntityToModelMap : Profile
    {
        public EntityToModelMap()
        {
            CreateMap<Campanha, CampanhaDto>();
            CreateMap<Campanha, CampanhasModel>();
        }
    }
}
