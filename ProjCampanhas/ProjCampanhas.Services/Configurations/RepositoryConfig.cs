using Microsoft.EntityFrameworkCore;
using ProjCampanhas.Domain.Interfaces;
using ProjCampanhas.Infra.Data.SqlServer.Contexts;
using ProjCampanhas.Infra.Data.SqlServer.Repositories;

namespace ProjCampanhas.Services.Configurations
{
    /// <summary>
    /// Classe para configuração de injeção de dependencia dos componentes da camada de repositório do sistema.
    /// </summary>
    public static class RepositoryConfig
    {
        public static void AddRepositoryConfig(WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

            var connectionString = builder.Configuration.GetConnectionString("BD_CAMP");

            builder.Services.AddDbContext<SqlServerContext>
                (options => options.UseSqlServer(connectionString));
        }
    }
}
