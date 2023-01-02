using System.Collections.Generic;
using System.Net;

namespace Dominio.Dto.Sistema
{
    public class RespuestaDto<T>
    {
        public List<string> Errores { get; set; }
        public string Mensaje { get; set; }
        public HttpStatusCode CodigoStatus { get; set; }
        public T Data { get; set; }
    }
}
