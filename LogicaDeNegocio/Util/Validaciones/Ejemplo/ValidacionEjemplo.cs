using System.Collections.Generic;
using Dominio.Dto.Ejemplo;

namespace LogicaDeNegocio.Util.Validaciones.Ejemplo
{
    public static class ValidacionEjemplo
    {
        public static EjemploResumenDto ObtenerModeloResumen(EjemploResumenSumatoriaDto resumen, IEnumerable<EjemploCuotaDto> cuotas)
        {
            return new EjemploResumenDto()
            {
                Resumen = resumen,
                Cuotas = cuotas
            };
        }
    }
}