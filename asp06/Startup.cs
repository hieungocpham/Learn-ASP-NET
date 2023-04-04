using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace asp06
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDistributedMemoryCache();
            services.AddSession( cfg => {
                cfg.Cookie.Name = "hieunp0801";
                cfg.IdleTimeout = new TimeSpan(0,60,0);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSession();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    // context.Session
                    await context.Response.WriteAsync("Hello World!");
                     int? count;
                    count = context.Session.GetInt32("count");
                    if (count == null){
                        count = 0;
                    }
                    await context.Response.WriteAsync($"truy cap {count}");
                });
                endpoints.MapGet("/session", async context =>
                {
                    // context.Session
                    int? count;
                    count = context.Session.GetInt32("count");
                    if (count == null){
                        count = 0;
                    }
                    count+=1;
                    context.Session.SetInt32("count",count.Value);
                    await context.Response.WriteAsync($"truy cap {count}");
                });
            });
        }
    }
}
