using System;
using NetCore.AutoRegisterDi;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Extension
{
    public static class ExtencionServiciosNegocio
    {
        public static void ResolverDependenciaServiciosNegocio(this IServiceCollection servicios)
        {
            var assemblyLogicaNegocio = AppDomain.CurrentDomain.Load("LogicaDeNegocio");

            servicios.RegisterAssemblyPublicNonGenericClasses(new Assembly[] { assemblyLogicaNegocio, assemblyLogicaNegocio })
                .Where(c => c.Name.Contains("ServicioNegocio"))
                .AsPublicImplementedInterfaces(ServiceLifetime.Transient);
        }
    }
}