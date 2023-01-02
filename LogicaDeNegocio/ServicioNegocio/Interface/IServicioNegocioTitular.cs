using Dominio.Dto.Titular;
using System.Threading.Tasks;

namespace LogicaDeNegocio.ServicioNegocio.Interface
{
    public interface IServicioNegocioTitular
    {
        Task<DatosTitularPorId> ObtenerDatosClientePorId(int idTitular);
        Task<DatosTitularPorDocumentoDto> ObtenerDatosTitularPorDocumento(FiltroBusquedaTitularDocumentoDto datosConsulta);
        Task<CrearClienteDto> CrearCliente(CrearClienteDto datosConsulta);
        Task<ActualizarClienteDto> ActualizarClienteDto(ActualizarClienteDto datosActualizacion);
    }
}