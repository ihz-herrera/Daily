
using Newtonsoft.Json;
using System.Net;

namespace BISoft.Ejercicios.Api.Controllers.Middlewares
{
    public class GlobalErrorMiddleware : IMiddleware
    {

        private readonly ILogger<GlobalErrorMiddleware> _logger;

        public GlobalErrorMiddleware(ILogger<GlobalErrorMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            //Antes de ejecutar los servicios
            try
            {
                await next(context);
                //Despues de ejecutar los servicios
            }
            catch (Exception ex)
            {
                _logger.LogError("Error en la petición: {0}", ex.Message);
                await HandleExceptionAsync(context, ex);
            }

            
           
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {

            var message = ex.Message;

            switch (ex)
            {
                case InvalidOperationException e:
                    _logger.LogInformation("Error de negocio: {0}", e.Message);
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                case KeyNotFoundException e:
                    _logger.LogDebug("Error de negocio: {0}", e.Message);
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;
                case ArgumentNullException e:
                    _logger.LogDebug("Error de negocio: {0}", e.Message);
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                case ArgumentException e:
                    _logger.LogDebug("Error de negocio: {0}", e.Message);
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                default:
                    _logger.LogError("Error interno del servidor: {0}", ex.Message);
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    message = "Error interno del servidor";
                    break;
            }

            

            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonConvert.SerializeObject(new { error = message }));


        }
    }


}
