using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;

namespace WebAPIDemo1.MiddleWare
{
    public class BookAPIMiddleWare
    {
        private readonly RequestDelegate _next;

        public BookAPIMiddleWare(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Log.Information("URL Hit Middleware");
            // Call the next delegate/middleware in the pipeline
            await _next(context);
        }
    }
}
