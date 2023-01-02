using Dominio.Dto.Sistema;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Enumeradores
{
    public class MensajesValidaciones
    {
        public enum MensajesCampos {

            [StringValue("El Formato de Correo electronico no es valido")]
            FormatoCorreoElectronicoInvalido = 1,
            [StringValue("El texto no tiene formato de base 64")]
            FormatoBase64Invalido = 2,

        }
    }
}
