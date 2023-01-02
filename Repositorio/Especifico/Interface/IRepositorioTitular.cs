using System.Threading.Tasks;
using Dominio.Dto.Titular;

namespace Repositorio.Especifico.Interface
{
    public interface IRepositorioTitular
    {
        Task<DatosTitularPorId> ObtenerDatosClientePorId(int idTitular);
        Task<DatosTitularPorDocumentoDto> ObtenerDatosTitularPorDocumento(FiltroBusquedaTitularDocumentoDto filtosDatosConsulta);
        Task<int> CrearCliente(CrearClienteDto datosConsulta);
        public Task<int> ActualizarClienteDto(ActualizarClienteDto datosActualizacion);
    }
}