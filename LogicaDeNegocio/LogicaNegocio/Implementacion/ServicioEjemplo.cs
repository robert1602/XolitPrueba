using System.Collections.Generic;
using System.Linq;
using Dominio.Dto.Ejemplo;
using LogicaDeNegocio.LogicaNegocio.Interface;

namespace LogicaDeNegocio.LogicaNegocio.Implementacion
{
    public class ServicioEjemplo : IServicioEjemplo
    {
        public IEnumerable<EjemploCuotaDto> CalcularCuotasSumatorias(EjemploResumenSumatoriaDto resumenEjemplo, int cantidadCuotas)
        {
            List<EjemploCuotaDto> cuotas = new List<EjemploCuotaDto>(capacity: cantidadCuotas);
            for (int cuotaTemporal = 0; cuotaTemporal < cantidadCuotas; cuotaTemporal++)
            {
                cuotas.Add(new EjemploCuotaDto()
                {
                    NumeroCuota = cuotaTemporal,
                    ValorCuota = (resumenEjemplo.Total / cantidadCuotas)
                });
            }
            return cuotas;
        }

        public EjemploResumenSumatoriaDto CalcularSumatoriaDatos(IEnumerable<EjemploDatosDto> obligacionesEjemplo)
        {
            decimal valorTotal = obligacionesEjemplo.Sum(obligacion => obligacion.Capital);
            decimal intereses = obligacionesEjemplo.Sum(obligacion => obligacion.Interes + obligacion.Mora);
            return new EjemploResumenSumatoriaDto()
            {
                Capital = valorTotal,
                Intereses = intereses
            };
        }
    }
}