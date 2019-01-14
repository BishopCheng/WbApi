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
using Microsoft.AspNetCore.HttpOverrides;
using APIPublish.Config;
using Configs;

namespace APIPublish
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            //配置跨域处理
            services.AddCors(options =>
            {
                options.AddPolicy("any", builder => {
                    builder.AllowAnyOrigin()   //允许任何来源主机访问
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials(); //处理Cookie

                });
            });

            //实体绑定
            //services.Configure<ServerUrl>(Configuration.GetSection("ServerUrl"));
            //var serverUrl = new ServerUrl();
            //Configuration.Bind("ServerUrl", serverUrl);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.


        /// <summary>
        /// 路由路径配置
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //路由配置
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                      name:"default",
                      template:"api/{controller}/{action}/{id?}",
                      defaults:new { Controllers="Values",action="GET" });
            }

          );

            //Http信息获取配置
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor
            |ForwardedHeaders.XForwardedProto
            });
        }
    }
}
