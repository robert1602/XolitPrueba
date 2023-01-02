using Dominio.Dto.Sistema;

namespace Dominio.Aplicacion.Implementacion
{
    public static class RespuestasServicios
    {
        public static RespuestaDto<T> RespuestaExitosa<T>(T datosRespuesta)
        {
            return new RespuestaDto<T>() { CodigoStatus = System.Net.HttpStatusCode.OK, Data = datosRespuesta };
        }

        public static RespuestaDto<T> RespuestaMalaSolicitud<T>(string mensajeError)
        {
            return new RespuestaDto<T>() { CodigoStatus = System.Net.HttpStatusCode.BadRequest, Mensaje = mensajeError };
        }
    }
}