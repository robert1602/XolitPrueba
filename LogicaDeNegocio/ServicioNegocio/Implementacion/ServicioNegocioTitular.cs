using System.Threading.Tasks;
using Dominio.Aplicacion.Implementacion;
using Dominio.Dto.Titular;
using Dominio.Exceptions;
using Dominio.Dto.Sistema;
using LogicaDeNegocio.ServicioNegocio.Interface;
using LogicaDeNegocio.Util.Mensajes.Generico;
using LogicaDeNegocio.Util.Validaciones;
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

        public Task<int> ActualizarClienteDto(ActualizarClienteDto datosActualizacion)
        {
            ActualizarClienteDto datosTitular = await this._unidadDeTrabajo.RepositorioTitular.CrearCliente(datosConsulta);
            return datosTitular;
        }

        public async Task<int> CrearCliente(CrearClienteDto datosConsulta)
        {
            CrearClienteDto datosTitularCliente = await this._unidadDeTrabajo.RepositorioTitular.CrearCliente(datosConsulta);
            return datosTitularCliente;
        }


        async Task<DatosTitularPorId> IServicioNegocioTitular.ObtenerDatosClientePorId(int idTitular)
        {
            DatosTitularPorId datosTitular = await this._unidadDeTrabajo.RepositorioTitular.ObtenerDatosClientePorId(idTitular);
            return datosTitular;
        }
        async Task<DatosTitularPorDocumentoDto> IServicioNegocioTitular.ObtenerDatosTitularPorDocumento(FiltroBusquedaTitularDocumentoDto datosConsulta)
        {
            DatosTitularPorDocumentoDto datosTitular1 = await this._unidadDeTrabajo.RepositorioTitular.ObtenerDatosTitularPorDocumento(datosConsulta);
            return datosTitular1;
        }

      
    }
}