using System.Collections.Generic;
using Dominio.Dto.Ejemplo;

namespace Repositorio.Especifico.Interface
{
    public interface IRepositorioEjemplo
    {
        IEnumerable<EjemploDatosDto> ObtenerDatosEjemplo();
    }
}