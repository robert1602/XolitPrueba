using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Dominio.Dto.Sistema;
using Dominio.Exceptions;

namespace Api.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                HttpResponse respuesta = context.Response;
                respuesta.ContentType = "application/json";
                List<string> errores = new List<string>();
                RespuestaDto<string> responseModel = new RespuestaDto<string> { CodigoStatus = HttpStatusCode.InternalServerError, Errores = errores };

                switch (error)
                {
                    case SystemPlusException specific:
                        responseModel.Errores = specific.Errores;
                        respuesta.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    default:
                        respuesta.StatusCode = (int)HttpStatusCode.InternalServerError;
                        responseModel.Errores.Add(error?.Message);
                        break;
                }

                var result = JsonSerializer.Serialize(responseModel);
                await respuesta.WriteAsync(result);
            }
        }

    }
}