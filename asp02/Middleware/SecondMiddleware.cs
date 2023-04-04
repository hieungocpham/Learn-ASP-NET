using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace asp02 {
    public class SecondMiddleware {
        private readonly RequestDelegate _next;
        public SecondMiddleware (RequestDelegate next) => _next = next;
        public async Task Invoke (HttpContext httpContext) {
            Console.WriteLine ("CheckAcessMiddleware: Cấm truy cập");
            await _next (httpContext);
        }
    }
}