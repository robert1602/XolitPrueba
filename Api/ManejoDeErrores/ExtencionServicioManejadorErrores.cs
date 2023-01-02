
using System;
using System.Diagnostics;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Dominio.Dto.Sistema;
using Dominio.Aplicacion.Implementacion;
using Api.Configuracion;
using Dominio.Exceptions;
using LogicaDeNegocio.Util.Validaciones;
using System.Net;

namespace Api.ManejoDeErrores
{
    public static class ExceptionErrorMiddleware
    {
        static readonly IConfigurationBuilder builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        static readonly IConfigurationRoot configuration = builder.Build();
        static ConfiguracionErrores configuracionApp = configuration.GetSection(ConfiguracionApi.ConfiguracionApp).GetSection(ConfiguracionApi.ConfiguracionErrores).Get<ConfiguracionErrores>();

        public static void ConfiguracionManejadorExcepciones(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(builder =>
            {
                builder.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    var caracteristicasContexto = context.Features.Get<IExceptionHandlerFeature>();
                    if (ValidacionGenerica.NoEsNulo(caracteristicasContexto))
                    {
                        bool errorDisparadoManual = caracteristicasContexto.Error is SystemPlusException;
                        string mensajeErrorUsuarioFinal = MensajeUsarioFinal(caracteristicasContexto.Error, errorDisparadoManual);
                        context.Response.StatusCode = errorDisparadoManual ? (int)HttpStatusCode.BadRequest : (int)HttpStatusCode.InternalServerError;
                        DetalleError detalleErrprConsulta = new DetalleError
                        {
                            Estatus = context.Response.StatusCode,
                            MensajeUsuarioFinal = mensajeErrorUsuarioFinal,
                            MensajeDesarrollador = errorDisparadoManual ? mensajeErrorUsuarioFinal : MensajeExcepcion(caracteristicasContexto.Error)
                        };
                        string fechaActual = string.Format("{0}", DateTime.Now.ToString("MMMM-yyyy"));
                        if (!errorDisparadoManual)
                            LogErrores.Escribir(fechaActual, detalleErrprConsulta.MensajeDesarrollador, "Contactabilidad", RutaLogs, new StackTrace(caracteristicasContexto.Error, true));
                        await context.Response.WriteAsync(errorDisparadoManual ? mensajeErrorUsuarioFinal : MensajeRespuesta(detalleErrprConsulta));
                    }
                });
            });
        }

        public static string MensajeExcepcion(Exception error) => error.Message;

        public static string MensajeUsarioFinal(Exception error, bool errorDisparadoManual) => errorDisparadoManual ? MensajeExcepcion(error) : ConfiguracionApi.ErrorInterno;

        public static string MensajeRespuesta(DetalleError error) => EsModoDebug() ? error.MensajeDesarrollador : error.MensajeUsuarioFinal;

        public static bool EsModoDebug()
        {
            string modoAplicacionAppSetting = configuracionApp.Modo;
            string modoAplicacionAmbiente = Environment.GetEnvironmentVariable(ConfiguracionApi.ModoAplicacion);
            return modoAplicacionAppSetting.Equals(modoAplicacionAmbiente);
        }

        public static string RutaLogs
        {
            get
            {
                string rutaLogs = configuracionApp.RutaLog;
                if (string.IsNullOrWhiteSpace(rutaLogs))
                    rutaLogs = Directory.GetCurrentDirectory() + @"\Log";

                if (!Directory.Exists(rutaLogs))
                    Directory.CreateDirectory(rutaLogs);

                return rutaLogs;
            }
        }
    }
}
