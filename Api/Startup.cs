using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NSwag.AspNetCore;
using Api.Extension;
using Api.Configuracion;
using Api.ManejoDeErrores;

namespace Api
{
    public class Startup
    {
        private readonly string CadenaConexion;
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            CadenaConexion = Configuration.GetConnectionString("BaseDeDatos");
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.ResolverDependenciaServiciosNegocio();
            services.ResolverDependenciaLogicaNegocio();
            services.ResolverDependenciaUnidadDeTrabajo(this.CadenaConexion);
            services.ResolverCors();
            services.ResolverDependenciaServiciosSwagger(this.Configuration);
            services.AddAutenticacionConSoporteDeAutenticacion(this.Configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();

            app.UseOpenApi();
            app.UseSwaggerUi3(settings =>
            {
                settings.DefaultModelsExpandDepth = ConfiguracionApi.ModelosNoVisibles;
                settings.OAuth2Client = new OAuth2ClientSettings
                {
                    ClientId = "5890ac83-afea-4d39-8c1a-51f8fa72f348",
                    AppName = "swagger-ui-cliente"
                };
            });

            app.UseRouting();
            // app.ConfiguracionManejadorExcepcionesConTry();
            app.ConfiguracionManejadorExcepciones();
            app.UseAuthentication();
            app.UseCors(ConfiguracionApi.NombreOrigenes);
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
