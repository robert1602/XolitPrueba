using Dominio.Dto.Titular;
using LogicaDeNegocio.ServicioNegocio.Interface;
using System.Threading.Tasks;
using UnidadDeTrabajo.Interface;

namespace LogicaDeNegocio.ServicioNegocio.Implementacion
{
    public class ServicioNegocioTitular : IServicioNegocioTitular
    {
        private readonly IFactoriaAbstractaRepositorios _unidadDeTrabajo;

        public ServicioNegocioTitular(IFactoriaAbstractaRepositorios unidadDeTrabajo)
        {
            this._unidadDeTrabajo = unidadDeTrabajo;
        }

        public async Task<ActualizarClienteDto> ActualizarClienteDto(ActualizarClienteDto datosActualizacion)
        {
            ActualizarClienteDto datosTitular = await this._unidadDeTrabajo.RepositorioTitular.ActualizarClienteDto(datosActualizacion);
            return datosTitular;
        }

        public async Task<CrearClienteDto> CrearCliente(CrearClienteDto datosConsulta)
        {
            CrearClienteDto datosTitularCliente = await this._unidadDeTrabajo.RepositorioTitular.CrearCliente(datosConsulta);
            return datosTitularCliente;
        }


        public async Task<DatosTitularPorId> ObtenerDatosClientePorId(int idTitular)
        {
            DatosTitularPorId datosTitular = await this._unidadDeTrabajo.RepositorioTitular.ObtenerDatosClientePorId(idTitular);
            return datosTitular;
        }
        public async Task<DatosTitularPorDocumentoDto> ObtenerDatosTitularPorDocumento(FiltroBusquedaTitularDocumentoDto datosConsulta)
        {
            DatosTitularPorDocumentoDto datosTitular1 = await this._unidadDeTrabajo.RepositorioTitular.ObtenerDatosTitularPorDocumento(datosConsulta);
            return datosTitular1;
        }
    }
}