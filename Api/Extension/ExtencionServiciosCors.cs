using Microsoft.Extensions.DependencyInjection;
using Api.Configuracion;

namespace Api.Extension
{
    public static class ExtencionServiciosCors
    {
        public static void ResolverCors(this IServiceCollection servicios)
        {
            servicios.AddCors(options =>
                        {
                            options.AddPolicy(name: ConfiguracionApi.NombreOrigenes,
                                builder =>
                                {
                                    builder.AllowAnyOrigin();
                                    builder.AllowAnyMethod();
                                    builder.AllowAnyHeader();
                                });
                        });
        }
    }
}