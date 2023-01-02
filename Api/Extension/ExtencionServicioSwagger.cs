using System.Collections.Generic;
using System.Linq;
using Api.Configuracion;
using Dominio.Aplicacion.Implementacion;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NSwag;
using NSwag.Generation.Processors.Security;

namespace Api.Extension
{
    public static class ExtencionServicioSwagger
    {
        public static void ResolverDependenciaServiciosSwagger(this IServiceCollection services, IConfiguration configuration)
        {
            ConfiguracionAzure configuracionAzure = configuration.GetSection(ConfiguracionApi.AzureActiveDirectory).Get<ConfiguracionAzure>();
            string scope = $"https://{configuracionAzure.Domain}{configuracionAzure.ClientId}/access_as_user";
            string autorizacion = $"{configuracionAzure.Instance}{configuracionAzure.Domain}{configuracionAzure.SignUpSignInPolicyId}/oauth2/v2.0/authorize";
            string token = $"{configuracionAzure.Instance}{configuracionAzure.Domain}{configuracionAzure.SignUpSignInPolicyId}/oauth2/v2.0/token";

            services.AddOpenApiDocument(document =>
            {
                document.Title = "Plantilla Micro Servicio API";
                document.Description = "Conjunto de end point expuestos como pruebas.";
                document.Version = "1.0";

                document.AddSecurity("bearer", Enumerable.Empty<string>(), new OpenApiSecurityScheme
                {
                    Type = OpenApiSecuritySchemeType.OAuth2,
                    Description = "B2C autenticaci�n",
                    Flow = OpenApiOAuth2Flow.Implicit,
                    Flows = new OpenApiOAuthFlows()
                    {
                        Implicit = new OpenApiOAuthFlow()
                        {
                            Scopes = new Dictionary<string, string> { { scope, "Acceso como usuario" } },
                            AuthorizationUrl = autorizacion,
                            TokenUrl = token
                        },
                    }
                });

                document.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("bearer"));
            });
        }
    }
}