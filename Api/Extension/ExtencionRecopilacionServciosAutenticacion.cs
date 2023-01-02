using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Web;
using Api.PoliticaAutorizacion;
using Api.Configuracion;

namespace Api.Extension
{
    public static class ExtencionRecopilacionServciosAutenticacion
    {
        public static void AddAutenticacionConSoporteDeAutenticacion(this IServiceCollection services, IConfiguration configuracion)
        {
            services.AddMicrosoftIdentityWebApiAuthentication(configuracion, ConfiguracionApi.AzureActiveDirectory)
                .EnableTokenAcquisitionToCallDownstreamApi()
                .AddInMemoryTokenCaches();

            services.AddSingleton<IAuthorizationHandler, ScopesHandler>();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("AccessAsUser",
                        policy => policy.Requirements.Add(new ScopesRequirement("access_as_user")));
            });

            services.AddControllers(configure =>
            {
                var policy = new AuthorizationPolicyBuilder()
                                .RequireAuthenticatedUser()
                                .Build();
                configure.Filters.Add(new AuthorizeFilter(policy));
            });
        }
    }
}
