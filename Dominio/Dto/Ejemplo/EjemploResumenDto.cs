using System.Collections.Generic;

namespace Dominio.Dto.Ejemplo
{
    public class EjemploResumenDto
    {
        public EjemploResumenSumatoriaDto Resumen { get; set; }
        public IEnumerable<EjemploCuotaDto> Cuotas { get; set; }
    }
}