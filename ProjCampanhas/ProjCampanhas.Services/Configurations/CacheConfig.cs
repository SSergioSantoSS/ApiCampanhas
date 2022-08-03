using Microsoft.Extensions.Options;
using ProjCampanhas.Infra.Cache.MongoDB.Contexts;
using ProjCampanhas.Infra.Cache.MongoDB.Interfaces;
using ProjCampanhas.Infra.Cache.MongoDB.Persistence;

namespace ProjCampanhas.Services.Configurations
{
    /// <summary>
    /// Classe para configuração de injeção de dependência dos componentes da camada de infraestrutura de cache do sistema
    /// </summary>
    public static class CacheConfig
    {
        public static void AddCacheConfig(WebApplicationBuilder builder)
        {            
            var mogoDBSettings = new MongoDBSettings();

            //capturar os parametros do appsettings.json
            new ConfigureFromConfigurationOptions<MongoDBSettings>(builder.Configuration.GetSection("mongoDBSettings"))
                .Configure(mogoDBSettings);

            //mapeando a injeção de dependência
            builder.Services.AddSingleton(mogoDBSettings);
            builder.Services.AddSingleton<MongoDBContext>();

            builder.Services.AddTransient<ICampanhasPersistence, CampanhasPersistence>();
        }
    }
}
