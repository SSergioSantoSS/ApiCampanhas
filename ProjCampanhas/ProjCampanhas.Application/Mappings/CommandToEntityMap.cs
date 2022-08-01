using AutoMapper;
using ProjCampanhas.Application.Commands;
using ProjCampanhas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjCampanhas.Application.Mappings
{
    // <summary>
    /// Classe de mapeamento de objetos COMMAND para => ENTITY
    /// </summary>
    public class CommandToEntityMap : Profile
    {
        public CommandToEntityMap()
        {
            CreateMap<CampanhaCreateCommand, Campanha>()
           .AfterMap((command, entity) =>
           {
               entity.Id = Guid.NewGuid();
               entity.CreatedAt = DateTime.Now;
               entity.UpdatedAt = DateTime.Now;
           });

            CreateMap<CampanhaUpdateCommand, Campanha>()
                .AfterMap((command, entity) =>
                {
                    entity.UpdatedAt = DateTime.Now;
                });
        }

    }
}
