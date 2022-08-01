using MediatR;
using ProjCampanhas.Application.Interfaces;
using ProjCampanhas.Application.Services;

namespace ProjCampanhas.Services.Configurations
{
    /// <summary>
    /// Classe para configuração de injeção de dependencia dos componentes da camada de aplicação do sistema.
    /// </summary>
    public static class ApplicationConfig
    {
        public static void AddApplicationConfig(WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<ICampanhaAppService, CampanhaAppService>();

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
