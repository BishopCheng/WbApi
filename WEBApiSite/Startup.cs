using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore;
using ApiServer.DataContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.Webpack;
 
namespace WEBApiSite
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        //注入依赖入口
        public void ConfigureServices(IServiceCollection services)
        {
            //由于DataContext和API不在同个项目，在此处注入
            var connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            services.AddDbContext<CompanySiteDataContexts>(options => options.UseMySQL(connectionString,b=>b.MigrationsAssembly("WEBApiSite")));
            //跨域处理机制
            services.AddCors(options =>
            {
                options.AddPolicy("any", bulider =>
                {
                    bulider.AllowAnyOrigin() //允许任意主机
                    .AllowAnyMethod()        //允许任意方法
                    .AllowAnyHeader()        //允许任意请求头
                    .AllowCredentials();     //允许证书（处理cookie ）
                });
            });
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseDeveloperExceptionPage();
            //注册路由
            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "actionRoute", template: "ActionApi/{controller}/{action}/{id?}");
                routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");

            });


        }
    }
}
