using Dominio.Dto.Sistema;

namespace Repositorio.Configuracion.Enum.Parametros
{
    public class EnumParametroTitular
    {
        public enum VariablesTitular
        {
            [StringValue("@titular_id")]
            TitularId = 1,
            [StringValue("@usuario_id")]
            UsuarioId = 2,
            [StringValue("@input_numero_documento")]
            InputNumeroDocumento = 3,
            [StringValue("@input_id_tipo_documento")]
            InputIdTipoDocumento = 4,
            [StringValue("@input_id_usuario")]
            InputIdUsuario = 5,

            [StringValue("@input_cliente_id")]
            InputClienteId = 6,
            [StringValue("@tipoDocumentoIdent")]
            TipoDocumentoIdent = 7,
            [StringValue("@identificacion")]
            Identificacion = 8,
            [StringValue("@nroCuenta")]
            NumeroCuenta = 9,
            [StringValue("@saldoinicial")]
            Saldoinicial = 10,
        }
    }
}