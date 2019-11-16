using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.SwaggerUI;
using WebApi.Utility.Swagger;

namespace WebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// 此方法由运行时调用。使用此方法向容器添加服务。
        /// </summary>
        /// <param name="services">指定服务描述符集合的契约。</param>
        [Obsolete]
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // Autofac

            #region Swagger
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("bus", new OpenApiInfo
                {
                    Title = "BUS",
                    Version = "V1",
                    Description = "这里是应用接口"
                });
                options.SwaggerDoc("org", new OpenApiInfo
                {
                    Title = "ORG",
                    Version = "V1",
                    Description = "这里是组织接口"
                });
                options.SwaggerDoc("sys", new OpenApiInfo
                {
                    Title = "SYS",
                    Version = "V1",
                    Description = "这里是系统接口"
                });
                // 包括XML注释中的描述
                DirectoryInfo d = new DirectoryInfo(AppContext.BaseDirectory);
                FileInfo[] files = d.GetFiles("*.xml");
                foreach (var item in files)
                {
                    options.IncludeXmlComments(item.FullName);
                };
                //options.IgnoreObsoleteActions();// swagger自带的特性过滤 对应特性[ApiExplorerSettings(IgnoreApi = true)]
                //options.DocumentFilter<IgnoreSysFilter>();
                //options.OperationFilter<SwaggerHeader>();// 生成器和过滤器，扩展UserHeader
                //给api添加token令牌证书
                //options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                //{
                //    Description = "JWT授权(数据将在请求头中进行传输) 直接在下框中输入Bearer {token}（注意两者之间是一个空格）\"",
                //    Name = "Authorization",//jwt默认的参数名称
                //    In = ParameterLocation.Header,//jwt默认存放Authorization信息的位置(请求头中)
                //    Type = SecuritySchemeType.ApiKey
                //});
            });
            #endregion
        }

        /// <summary>
        ///  This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        ///  此方法由运行时调用。使用此方法配置HTTP请求管道。
        /// </summary>
        /// <param name="app">应用程序的组装者</param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            #region 启用Swagger
            //启用中间件服务生成Swagger作为JSON终结点
            app.UseSwagger();
            //启用中间件服务对swagger-ui，指定Swagger JSON终结点
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/bus/swagger.json", "bus");
                c.SwaggerEndpoint("/swagger/org/swagger.json", "org");
                c.SwaggerEndpoint("/swagger/sys/swagger.json", "sys");
                c.RoutePrefix = string.Empty;// 在跟目录提供Swagger UI
                c.DocumentTitle = ""; // 文档标题
                //c.InjectStylesheet("/swagger-ui/custom.css");// 注入自定义css
                c.DocExpansion(DocExpansion.None);// 默认收缩接口方法
            });
            #endregion
        }
    }
}
