using System.Collections.Generic;
using System.Threading.Tasks;
using Dominio.Dto.Ejemplo;
using Dominio.Dto.Sistema;

namespace LogicaDeNegocio.ServicioNegocio.Interface
{
    public interface IServicioNegocioEjemplo
    {
        Task<RespuestaDto<IEnumerable<EjemploDatosDto>>> ObtenerDatosEjemplo();
        Task<RespuestaDto<EjemploResumenDto>> ObtenerResumenDatosEjemplo(int cantidadCuotas);
        Task<RespuestaDto<IEnumerable<object>>> CrearEjemplo();
        Task<RespuestaDto<IEnumerable<object>>> ActualizarEjemplo();
        Task<RespuestaDto<IEnumerable<object>>> EliminarEjemplo();
    }
}