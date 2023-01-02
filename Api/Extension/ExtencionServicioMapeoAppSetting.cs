using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Dominio.Sistema;

namespace Api.Extension
{
    public static class ExtencionServicioMapeoAppSetting
    {
        public static void ResolverDependenciaMapeoAppSetting(this IServiceCollection servicios, IConfiguration configuration)
        {
            IConfigurationSection configuracionesApp = configuration.GetSection("ConfiguracionApp");
            servicios.Configure<ConfiguracionApp>(configuracionesApp);
        }
    }
}