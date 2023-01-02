using System;
using System.Reflection;
using NetCore.AutoRegisterDi;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Extension
{
    public static class ExtencionServiciosLogicaNegocio
    {
        public static void ResolverDependenciaLogicaNegocio(this IServiceCollection servicios)
        {
            var assemblyLogicaNegocio = AppDomain.CurrentDomain.Load("LogicaDeNegocio");

            servicios.RegisterAssemblyPublicNonGenericClasses(new Assembly[] { assemblyLogicaNegocio, assemblyLogicaNegocio })
                .Where(c => c.Name.Contains("Servicio"))
                .AsPublicImplementedInterfaces(ServiceLifetime.Transient);
        }
    }
}