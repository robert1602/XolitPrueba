using Dominio.Dto.Titular;
using System.Threading.Tasks;

namespace LogicaDeNegocio.ServicioNegocio.Interface
{
    public interface IServicioNegocioTitular
    {
        Task<DatosTitularPorId> ObtenerDatosClientePorId(int idTitular);
        Task<DatosTitularPorDocumentoDto> ObtenerDatosTitularPorDocumento(FiltroBusquedaTitularDocumentoDto datosConsulta);
        Task <int>CrearCliente(CrearClienteDto datosConsulta);
        Task <int> ActualizarClienteDto(ActualizarClienteDto datosActualizacion);
    }
}