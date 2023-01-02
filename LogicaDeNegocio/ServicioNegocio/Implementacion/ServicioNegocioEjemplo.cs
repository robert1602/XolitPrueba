using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dominio.Aplicacion.Implementacion;
using Dominio.Dto.Ejemplo;
using Dominio.Dto.Sistema;
using Dominio.Exceptions;
using LogicaDeNegocio.LogicaNegocio.Interface;
using LogicaDeNegocio.ServicioNegocio.Interface;
using LogicaDeNegocio.Util.Mensajes.Generico;
using LogicaDeNegocio.Util.Validaciones;
using LogicaDeNegocio.Util.Validaciones.Ejemplo;
using UnidadDeTrabajo.Interface;

namespace LogicaDeNegocio.ServicioNegocio.Implementacion
{
    public class ServicioNegocioEjemplo : IServicioNegocioEjemplo
    {
        private readonly IServicioEjemplo _servicioEjemplo;
        private readonly IFactoriaAbstractaRepositorios _unidadDeTrabajo;
        
        public ServicioNegocioEjemplo(IFactoriaAbstractaRepositorios unidadDeTrabajo, IServicioEjemplo servicioEjemplo)
        {
            this._unidadDeTrabajo = unidadDeTrabajo;
            this._servicioEjemplo = servicioEjemplo;
        }

        public async Task<RespuestaDto<IEnumerable<object>>> ActualizarEjemplo()
        {
            throw new SystemPlusException(MensajeGenerico.NoImplementado);
        }

        public async Task<RespuestaDto<IEnumerable<object>>> CrearEjemplo()
        {
            throw new NotImplementedException();
        }

        public async Task<RespuestaDto<IEnumerable<object>>> EliminarEjemplo()
        {
            throw new SystemPlusException(MensajeGenerico.NoImplementado);
        }

        public async Task<RespuestaDto<IEnumerable<EjemploDatosDto>>> ObtenerDatosEjemplo()
        {
            IEnumerable<EjemploDatosDto> obligacionesEjemplo = this._unidadDeTrabajo.RepositorioEjemplo.ObtenerDatosEjemplo();
            return ValidacionGenerica.PoseeRegistros(obligacionesEjemplo) ?
                        RespuestasServicios.RespuestaExitosa<IEnumerable<EjemploDatosDto>>(obligacionesEjemplo) :
                        RespuestasServicios.RespuestaMalaSolicitud<IEnumerable<EjemploDatosDto>>(MensajeGenerico.SinDatos);
        }

        public async Task<RespuestaDto<EjemploResumenDto>> ObtenerResumenDatosEjemplo(int cantidadCuotas)
        {
            IEnumerable<EjemploDatosDto> obligacionesEjemplo = this._unidadDeTrabajo.RepositorioEjemplo.ObtenerDatosEjemplo();
            EjemploResumenSumatoriaDto resumen = this._servicioEjemplo.CalcularSumatoriaDatos(obligacionesEjemplo);
            IEnumerable<EjemploCuotaDto> cuotas = this._servicioEjemplo.CalcularCuotasSumatorias(resumen, cantidadCuotas);
            return RespuestasServicios.RespuestaExitosa<EjemploResumenDto>(ValidacionEjemplo.ObtenerModeloResumen(resumen, cuotas));
        }
    }
}