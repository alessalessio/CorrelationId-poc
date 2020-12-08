using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.CorrelationId.Middlewares
{
    public class LogHeaderMiddleware
    {
        private readonly RequestDelegate _next;

        public LogHeaderMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var header = context.Request.Headers["CorrelationId"];
            string correlationId; 
            if (header.Count > 0)
            {
                correlationId = header[0];
            }
            else
            {
                correlationId = Guid.NewGuid().ToString();
            }

            var logger = context.RequestServices.GetRequiredService<ILogger<LogHeaderMiddleware>>();
            using (logger.BeginScope("{@CorrelationId}", correlationId))
            {
                await this._next(context);
            }
        }
    }
}
