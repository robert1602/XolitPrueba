using Dominio.Dto.Sistema;

namespace Repositorio.Enumerables.ProcedimientosAlmacenados
{
    public class ProcedimientoTitular
    {
        public enum ProcedimientosTitular
        {
            [StringValue("titular_sp_obtener_dato_personal_por_id")]
            SpObtenerDatosTitularPorId = 1,
            [StringValue("titular_sp_obtener_titular_por_cedula")]
            SpObtenerDatosTitularPorDocumento = 2,

            [StringValue("sp_crea_o_actualiza_cliente")]
            SpcreaOActualizaCliente = 2,
        }
    }
}
