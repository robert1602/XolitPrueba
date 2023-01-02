
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Repositorio.Generico.Interface;
using System.Data.SqlClient;

namespace Repositorio.Generico.Implementacion
{
    public class RepositorioConsultaDatos : IRepositorioConsultaDatos
    {
        private readonly string _cadenaConexion;

        public RepositorioConsultaDatos(string cadenaConexion)
        {
            this._cadenaConexion = cadenaConexion;
        }

        public async Task<IEnumerable<T>> EjecutarStoredProcedurePorParametroTabla<T>(string scriptAEjecutar, object parametros, CommandType comando)
        {
            using (SqlConnection conexion = new SqlConnection(this._cadenaConexion))
            {
                return await conexion.QueryAsync<T>(scriptAEjecutar, parametros, commandType: comando);
            }
        }

        public async Task<IEnumerable<T>> EjecutarStoredProcedurePorParametro<T>(CommandType comando, string scriptAEjecutar, Dictionary<string, object> parametros = null)
        {
            DynamicParameters parametrosConsulta = parametros != null ? this.InicializarParametros(parametros) : new DynamicParameters();
            using (SqlConnection conexion = new SqlConnection(this._cadenaConexion))
            {
                return await conexion.QueryAsync<T>(scriptAEjecutar, parametros, commandType: comando);
            }
        }

        private DynamicParameters InicializarParametros(Dictionary<string, object> parametrosOriginales)
        {
            DynamicParameters parametrosConsulta = new DynamicParameters();
            foreach (var parametro in parametrosOriginales)
            {
                parametrosConsulta.Add(parametro.Key, parametro.Value);
            }
            return parametrosConsulta;
        }
    }
}