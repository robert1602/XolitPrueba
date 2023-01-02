using System.Threading.Tasks;
using Dominio.Dto.Titular;

namespace Repositorio.Especifico.Interface
{
    public interface IRepositorioTitular
    {
        Task<DatosTitularPorId> ObtenerDatosClientePorId(int idTitular);
        Task<DatosTitularPorDocumentoDto> ObtenerDatosTitularPorDocumento(FiltroBusquedaTitularDocumentoDto filtosDatosConsulta);
        Task<CrearClienteDto> CrearCliente(CrearClienteDto datosConsulta);
        Task<ActualizarClienteDto> ActualizarClienteDto(ActualizarClienteDto datosActualizacion);
    }
}