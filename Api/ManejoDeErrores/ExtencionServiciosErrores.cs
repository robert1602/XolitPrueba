using Microsoft.AspNetCore.Builder;
using Api.Middleware;

namespace Api.ManejoDeErrores
{
    public static class ExtencionServiciosErrores
    {
        public static void ConfiguracionManejadorExcepcionesConTry(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlerMiddleware>();
        }
    }
}