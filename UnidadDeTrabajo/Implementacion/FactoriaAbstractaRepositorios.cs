using Repositorio.Especifico.Implementacion;
using Repositorio.Especifico.Interface;
using Repositorio.Generico.Implementacion;
using Repositorio.Generico.Interface;
using UnidadDeTrabajo.Interface;

namespace UnidadDeTrabajo.Implementacion
{
    public class FactoriaAbstractaRepositorios : IFactoriaAbstractaRepositorios
    {
        public IRepositorioConsultaDatos RepositorioConsultaDatos { get; private set; }
        public IRepositorioTitular RepositorioTitular { get; private set; }
        public IRepositorioEjemplo RepositorioEjemplo { get; private set; }

        public FactoriaAbstractaRepositorios(string cadenaConexion)
        {
            this.RepositorioConsultaDatos = new RepositorioConsultaDatos(cadenaConexion);
            this.RepositorioEjemplo = new RepositorioEjemplo(this.RepositorioConsultaDatos);
            this.RepositorioTitular = new RepositorioTitular(this.RepositorioConsultaDatos);
        }
    }
}
