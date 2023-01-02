using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Aplicacion.Implementacion;
using Dominio.Dto.Titular;
using Repositorio.Configuracion.ListadoParametros.Titular;
using Repositorio.Generico.Interface;
using static Repositorio.Enumerables.ProcedimientosAlmacenados.ProcedimientoTitular;

namespace Repositorio.Especifico.Interface
{
    public class RepositorioTitular : IRepositorioTitular
    {
        private readonly IRepositorioConsultaDatos _repositorioConsultaDatos;

        public RepositorioTitular(IRepositorioConsultaDatos repositorioConsultaDatos)
        {
            this._repositorioConsultaDatos = repositorioConsultaDatos;
        }

        public async Task<DatosTitularPorDocumentoDto> ObtenerDatosTitularPorDocumento(FiltroBusquedaTitularDocumentoDto filtosDatosConsulta)
        {
            Dictionary<string, object> parametrosConsulta = ParametroTitular.ConsultaTitularPorDocumento(filtosDatosConsulta);
            string nombreProcedimiento = EnumValor.GetStringValue(ProcedimientosTitular.SpObtenerDatosTitularPorDocumento);
            return (await this._repositorioConsultaDatos.EjecutarStoredProcedurePorParametro<DatosTitularPorDocumentoDto>(CommandType.StoredProcedure, nombreProcedimiento, parametrosConsulta))
                    .FirstOrDefault();
        }

        public async Task<DatosTitularPorId> ObtenerDatosClientePorId(int idTitular)
        {
            Dictionary<string, object> parametrosConsulta = ParametroTitular.ConsultaClientPorId(idTitular);
            string nombreProcedimiento = EnumValor.GetStringValue(ProcedimientosTitular.SpObtenerDatosTitularPorId);
            return (await this._repositorioConsultaDatos.EjecutarStoredProcedurePorParametro<DatosTitularPorId>(CommandType.StoredProcedure, nombreProcedimiento, parametrosConsulta))
                    .FirstOrDefault();
        }

        public async Task<CrearClienteDto> CrearCliente(CrearClienteDto datosConsulta)
        {
            Dictionary<string, object> parametrosConsulta = ParametroTitular.CrearCliente(datosConsulta);
            string nombreProcedimiento = EnumValor.GetStringValue(ProcedimientosTitular.SpcreaOActualizaCliente);
            return (await this._repositorioConsultaDatos.EjecutarStoredProcedurePorParametro<CrearClienteDto>(CommandType.StoredProcedure, nombreProcedimiento, parametrosConsulta))
                    .FirstOrDefault();
        }

        public async Task<ActualizarClienteDto> ActualizarClienteDto(ActualizarClienteDto datosActualizacion)
        {
            Dictionary<string, object> parametrosConsulta = ParametroTitular.ActualizarClientPorId(datosActualizacion);
            string nombreProcedimiento = EnumValor.GetStringValue(ProcedimientosTitular.SpcreaOActualizaCliente);
            return (await this._repositorioConsultaDatos.EjecutarStoredProcedurePorParametro<ActualizarClienteDto>(CommandType.StoredProcedure, nombreProcedimiento, parametrosConsulta))
                    .FirstOrDefault();
        }
    }
}