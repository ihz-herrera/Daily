
using Serilog.Context;

namespace BISoft.Ejercicios.Api.Controllers.Middlewares
{
    public class TraceIdentifierMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var traceIdentifier = context.Request.Headers["X-TraceIdentifier"]
                .FirstOrDefault(); 

            if (string.IsNullOrWhiteSpace(traceIdentifier))
                traceIdentifier = context.TraceIdentifier;

            LogContext.PushProperty("TraceIdentifier", traceIdentifier);

            

            context.Response.Headers.Add("X-TraceIdentifier", traceIdentifier);
            await next(context);

            
             

        }
    }
}
