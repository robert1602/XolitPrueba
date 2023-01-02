using System.Collections.Generic;
using Dominio.Dto.Ejemplo;

namespace LogicaDeNegocio.LogicaNegocio.Interface
{
    public interface IServicioEjemplo
    {
        EjemploResumenSumatoriaDto CalcularSumatoriaDatos(IEnumerable<EjemploDatosDto> obligacionesEjemplo);
        IEnumerable<EjemploCuotaDto> CalcularCuotasSumatorias(EjemploResumenSumatoriaDto resumenEjemplo, int cantidadCuotas);
    }
}