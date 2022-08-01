using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjCampanhas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjCampanhas.Infra.Data.SqlServer.Configurations
{
    /// <summary>
    /// Mapeamento ORM da entidade Campanha
    /// </summary>

    public class CampanhaConfiguration : IEntityTypeConfiguration<Campanha>
    {
        public void Configure(EntityTypeBuilder<Campanha> builder)
        {
            builder.HasIndex(c => c.Nome).IsUnique();
            builder.HasIndex(c => c.Codigo).IsUnique();
            

        }
    }
}
