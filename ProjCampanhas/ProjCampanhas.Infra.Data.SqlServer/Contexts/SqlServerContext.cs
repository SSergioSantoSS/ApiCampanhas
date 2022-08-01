using Microsoft.EntityFrameworkCore;
using ProjCampanhas.Domain.Entities;
using ProjCampanhas.Infra.Data.SqlServer.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjCampanhas.Infra.Data.SqlServer.Contexts
{

    /// <summary>
    /// Classe de contexto do EntityFramework para o SqlServer
    /// </summary>
    public class SqlServerContext : DbContext
    {
        public SqlServerContext(DbContextOptions<SqlServerContext> dbContextOptions)
            : base(dbContextOptions)//construtor da superclass (DbContext)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CampanhaConfiguration());
        }

        public DbSet<Campanha>? Campanhas { get; set; }
    }
}
