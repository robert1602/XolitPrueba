using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Repositorio.Generico.Interface
{
    public interface IRepositorioConsultaDatos
    {
        Task<IEnumerable<T>> EjecutarStoredProcedurePorParametro<T>(CommandType comando, string scriptAEjecutar, Dictionary<string, object> parametros = null);
    }
}