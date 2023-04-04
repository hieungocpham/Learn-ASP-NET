using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace asp03
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    string menu = HtmlHelper.MenuTop (HtmlHelper.DefaultMenuTopItems (), context.Request);
                    string content = HtmlHelper.HtmlTrangchu ();
                    string html = HtmlHelper.HtmlDocument ("Trang chủ", menu + content);
                    await context.Response.WriteAsync (html);
                });
                endpoints.Map("/RequestInfo", async context => {
                    // xây dựng chức năng /RequestInfo ở đây
                    await context.Response.WriteAsync("/RequestInfo");
                });

                endpoints.MapGet("/Encoding", async context => {
                    // xây dựng chức năng Encoding  ở đây
                    await context.Response.WriteAsync("/Encoding");
                });

                endpoints.MapGet("/Cookies/{*action}", async context => {
                    // xây dựng chức năng Cookies ở đây
                    await context.Response.WriteAsync("/Cookies");
                });
                
            });
            app.Map("/Json", app => {
                app.Run(async context => {
                    // code ở đây
                    await context.Response.WriteAsync("/Json");
                });
            });

            // Điểm rẽ nhánh pipeline khi URL là /Form
            app.Map("/Form", app => {
                app.Run(async context => {
                    // code ở đây
                    string menu = HtmlHelper.MenuTop (HtmlHelper.DefaultMenuTopItems (), context.Request);
                    string formhtml = await RequestProcess.FormProcess (context.Request);
                    formhtml = formhtml.HtmlTag ("div", "container");
                    string html = HtmlHelper.HtmlDocument ("Form Post", (menu + formhtml));
                    await context.Response.WriteAsync (html);
                });
            });


            app.Run (async (HttpContext context) => {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                await context.Response.WriteAsync ("Page not found!");
            });
        }
    }
}
