using System.Collections.Generic;
using Dominio.Dto.Ejemplo;
using Repositorio.Especifico.Interface;
using Repositorio.Generico.Interface;

namespace Repositorio.Especifico.Implementacion
{
    public class RepositorioEjemplo : IRepositorioEjemplo
    {
        private readonly IRepositorioConsultaDatos _repositorioConsultaDatos;

        public RepositorioEjemplo(IRepositorioConsultaDatos repositorioConsultaDatos)
        {
            this._repositorioConsultaDatos = repositorioConsultaDatos;
        }

        public IEnumerable<EjemploDatosDto> ObtenerDatosEjemplo()
        {
            List<EjemploDatosDto> obligacionesTempo = new List<EjemploDatosDto>(capacity: 5);
            obligacionesTempo.Add(new EjemploDatosDto() { Capital = 30000M, Interes = 50000M, Mora = 70000M });
            obligacionesTempo.Add(new EjemploDatosDto() { Capital = 40000M, Interes = 50000M, Mora = 70000M });
            obligacionesTempo.Add(new EjemploDatosDto() { Capital = 50000M, Interes = 50000M, Mora = 70000M });
            obligacionesTempo.Add(new EjemploDatosDto() { Capital = 60000M, Interes = 50000M, Mora = 70000M });
            obligacionesTempo.Add(new EjemploDatosDto() { Capital = 70000M, Interes = 50000M, Mora = 70000M });
            return obligacionesTempo;
        }
    }
}