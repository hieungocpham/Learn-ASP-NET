using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using asp07.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace asp07
{
    public class Startup
    {
        IConfiguration _configuration;
        public Startup(IConfiguration configuration){
            _configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions ();                                         // Kích hoạt Options
            var mailsettings = _configuration.GetSection ("MailSettings");  // đọc config
            services.Configure<MailSettings> (mailsettings);
            services.AddTransient<SendMailService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
                endpoints.MapGet("/testSendMail", async context =>
                {
                    string notice = await MailUtils.MailUtils.SendMail("hieunp0801@gmail.com","hieunp0801@gmail.com","Tieu de","Noidung");
                    await context.Response.WriteAsync(notice);
                });
                endpoints.MapGet("/testGmail", async context =>
                {
                    string notice = await MailUtils.MailUtils.SendGmail("hieuasp0801@gmail.com","hieunp0801@gmail.com","Tieu de","Noidung","hieuasp0801@gmail.com","xchqfwnetrbttlml");
                    await context.Response.WriteAsync(notice);
                });
                endpoints.MapGet("/sendMailsv", async context =>
                {
                    var sendMailService = context.RequestServices.GetService<SendMailService>();
                    MailContent mail = new MailContent();
                    mail.To = "hieunp0801@gmail.com";
                    mail.Subject = "Kiểm tra thử";
                    mail.Body = "<p><strong>Xin chào xuanthulab.net</strong></p>";

                    var  kq = await sendMailService.SendMail(mail);
                    await context.Response.WriteAsync(kq.ToString());
                });
            });
        }
    }
}
