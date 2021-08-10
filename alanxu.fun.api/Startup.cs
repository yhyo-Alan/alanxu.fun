using alanxu.fun.di;
using alanxu.fun.entity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace alanxu.fun.api
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

            services.AddControllers();

            #region mysql
            string conStr = Configuration.GetConnectionString("MySql");
            ServerVersion sv = ServerVersion.AutoDetect(conStr);
            services.AddDbContext<AlanXuFunContext>(options => options.UseMySql(conStr, sv));
            #endregion

            services.AddDI();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "alanxu.fun.api",
                    Version = "v1",
                    Contact = new OpenApiContact()
                    {
                        Name = "Alan Xu",
                        Url = new Uri("http://alanxu.fun")
                    }
                });
                //反射获取xml文件，并构造文件路径
                string xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //启用xml注释，第二个参数表示启用控制器注释
                //如果报找不到xml路径，可以在项目文件添加如下代码：
                //<PropertyGroup Condition = "'$(Configuration)|$(Platform)'=='Debug|AnyCPU'" >
                //<GenerateDocumentationFile > true </ GenerateDocumentationFile >
                //<NoWarn>$(NoWarn); 1591 </ NoWarn >
                //</PropertyGroup >
                c.IncludeXmlComments(xmlPath, true);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "alanxu.fun.api v1");
                    c.DocExpansion(DocExpansion.None);//折叠
                    c.DefaultModelsExpandDepth(-1);//不显示swagger界面的Schemas节点
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
