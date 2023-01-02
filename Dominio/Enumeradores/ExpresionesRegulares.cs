using Dominio.Dto.Sistema;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Enumeradores
{
    public class ExpresionesRegulares
    {
        public enum ValidacionesAlfabeticas { 
        }

        public enum ValidacionesTipoCampo
        {
            [StringValue("^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\\.[a-zA-Z0-9-]+)*$")]
            CorreoElectronico =1,
            
        }
        public enum ValidacionesTipoTexto { 
            [StringValue("^([A-Za-z0-9+/]{4})*([A-Za-z0-9+/]{4}|[A-Za-z0-9+/]{3}=|[A-Za-z0-9+/]{2}==)$")]
            Base64=1,
        }
    }
}
