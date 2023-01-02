using System.Collections.Generic;
using Dominio.Aplicacion.Implementacion;
using Dominio.Dto.Titular;
using static Repositorio.Configuracion.Enum.Parametros.EnumParametroTitular;

namespace Repositorio.Configuracion.ListadoParametros.Titular
{
    public static class ParametroTitular
    {
        public static Dictionary<string, object> ConsultaClientPorId(int idTitular)
        {
            string titularId = EnumValor.GetStringValue(VariablesTitular.TitularId);
            //string usuarioId = EnumValor.GetStringValue(VariablesTitular.UsuarioId);

            Dictionary<string, object> parametrosConsulta = new Dictionary<string, object>();
            parametrosConsulta.Add(titularId, idTitular);
            //parametrosConsulta.Add(usuarioId, idUsuarioSystem);
            return parametrosConsulta;
        }
        public static Dictionary<string, object> CrearCliente(CrearClienteDto datosConsulta)
        {
            string tipoDocumentoIdent = EnumValor.GetStringValue(VariablesTitular.TipoDocumentoIdent);
            string identificacion = EnumValor.GetStringValue(VariablesTitular.Identificacion);
            string numeroCuenta = EnumValor.GetStringValue(VariablesTitular.NumeroCuenta);
            string saldoinicial = EnumValor.GetStringValue(VariablesTitular.Saldoinicial);

            Dictionary<string, object> parametrosConsulta = new Dictionary<string, object>();
            parametrosConsulta.Add(tipoDocumentoIdent, datosConsulta.TipoDocumentoIdent);
            parametrosConsulta.Add(identificacion, datosConsulta.Identificacion);
            parametrosConsulta.Add(numeroCuenta, datosConsulta.NroCuenta);
            parametrosConsulta.Add(saldoinicial, datosConsulta.Saldoinicial);
            return parametrosConsulta;
        }
        public static Dictionary<string, object> ActualizarClientPorId(ActualizarClienteDto datosActualizacion)
        {
            string clienteId = EnumValor.GetStringValue(VariablesTitular.InputClienteId);
            string tipoDocumentoIdent = EnumValor.GetStringValue(VariablesTitular.TipoDocumentoIdent);
            string identificacion = EnumValor.GetStringValue(VariablesTitular.Identificacion);
            string numeroCuenta = EnumValor.GetStringValue(VariablesTitular.NumeroCuenta);
            string saldoinicial = EnumValor.GetStringValue(VariablesTitular.Saldoinicial);

            Dictionary<string, object> parametrosConsulta = new Dictionary<string, object>();
            parametrosConsulta.Add(clienteId, datosActualizacion.IdCliente);
            parametrosConsulta.Add(tipoDocumentoIdent, datosActualizacion.TipoDocumentoIdent);
            parametrosConsulta.Add(identificacion, datosActualizacion.Identificacion);
            parametrosConsulta.Add(numeroCuenta, datosActualizacion.NroCuenta);
            parametrosConsulta.Add(saldoinicial, datosActualizacion.Saldoinicial);
            return parametrosConsulta;
        }
        public static Dictionary<string, object> ConsultaTitularPorDocumento(FiltroBusquedaTitularDocumentoDto filtosDatosConsulta)
        {
            string numeroDocumento = EnumValor.GetStringValue(VariablesTitular.InputNumeroDocumento);
            string idTipoDocumento = EnumValor.GetStringValue(VariablesTitular.InputIdTipoDocumento);
            string idUsuario = EnumValor.GetStringValue(VariablesTitular.InputIdUsuario);

            Dictionary<string, object> parametrosConsulta = new Dictionary<string, object>();
            parametrosConsulta.Add(numeroDocumento, filtosDatosConsulta.NumeroDocumento);
            parametrosConsulta.Add(idTipoDocumento, filtosDatosConsulta.IdTipoDocumento);
            parametrosConsulta.Add(idUsuario, filtosDatosConsulta.IdUsuario);
            return parametrosConsulta;
        }
    }
}