using Repositorio.Especifico.Interface;
using Repositorio.Generico.Interface;

namespace UnidadDeTrabajo.Interface
{
    public interface IFactoriaAbstractaRepositorios
    {
        IRepositorioConsultaDatos RepositorioConsultaDatos { get; }
        IRepositorioEjemplo RepositorioEjemplo { get; }
        IRepositorioTitular RepositorioTitular { get; }
    }
}
