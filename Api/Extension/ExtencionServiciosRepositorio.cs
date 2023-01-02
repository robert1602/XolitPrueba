using System;
using Microsoft.Extensions.DependencyInjection;
using UnidadDeTrabajo.Implementacion;
using UnidadDeTrabajo.Interface;

namespace Api.Extension
{
    public static class ExtencionServiciosRepositorio
    {
        public static void ResolverDependenciaUnidadDeTrabajo(this IServiceCollection services, string cadenaConexion)
        {
            services.AddSingleton((Func<IServiceProvider, IFactoriaAbstractaRepositorios>)(option => new FactoriaAbstractaRepositorios(cadenaConexion)));
            services.AddSingleton((Func<IServiceProvider, IFactoriaAbstractaInfraestructura>)(option => new FactoriaAbstractaInfraestructura()));
        }
    }
}