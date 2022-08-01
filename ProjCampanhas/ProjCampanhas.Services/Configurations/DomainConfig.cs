using ProjCampanhas.Domain.Interfaces;
using ProjCampanhas.Domain.Services;

namespace ProjCampanhas.Services.Configurations
{
    /// <summary>
    /// Classe para configuração de injeção de dependencia dos componentes da camada de domínio do sistema.
    /// </summary>
    public static class DomainConfig
    {
        public static void AddDomainConfig(WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<ICampanhaDomainService, CampanhaDomainService>();
        }
    }
}
