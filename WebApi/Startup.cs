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
        /// �˷���������ʱ���á�ʹ�ô˷�����������ӷ���
        /// </summary>
        /// <param name="services">ָ���������������ϵ���Լ��</param>
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
                    Description = "������Ӧ�ýӿ�"
                });
                options.SwaggerDoc("org", new OpenApiInfo
                {
                    Title = "ORG",
                    Version = "V1",
                    Description = "��������֯�ӿ�"
                });
                options.SwaggerDoc("sys", new OpenApiInfo
                {
                    Title = "SYS",
                    Version = "V1",
                    Description = "������ϵͳ�ӿ�"
                });
                // ����XMLע���е�����
                DirectoryInfo d = new DirectoryInfo(AppContext.BaseDirectory);
                FileInfo[] files = d.GetFiles("*.xml");
                foreach (var item in files)
                {
                    options.IncludeXmlComments(item.FullName);
                };
                //options.IgnoreObsoleteActions();// swagger�Դ������Թ��� ��Ӧ����[ApiExplorerSettings(IgnoreApi = true)]
                //options.DocumentFilter<IgnoreSysFilter>();
                //options.OperationFilter<SwaggerHeader>();// �������͹���������չUserHeader
                //��api���token����֤��
                //options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                //{
                //    Description = "JWT��Ȩ(���ݽ�������ͷ�н��д���) ֱ�����¿�������Bearer {token}��ע������֮����һ���ո�\"",
                //    Name = "Authorization",//jwtĬ�ϵĲ�������
                //    In = ParameterLocation.Header,//jwtĬ�ϴ��Authorization��Ϣ��λ��(����ͷ��)
                //    Type = SecuritySchemeType.ApiKey
                //});
            });
            #endregion
        }

        /// <summary>
        ///  This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        ///  �˷���������ʱ���á�ʹ�ô˷�������HTTP����ܵ���
        /// </summary>
        /// <param name="app">Ӧ�ó������װ��</param>
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

            #region ����Swagger
            //�����м����������Swagger��ΪJSON�ս��
            app.UseSwagger();
            //�����м�������swagger-ui��ָ��Swagger JSON�ս��
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/bus/swagger.json", "bus");
                c.SwaggerEndpoint("/swagger/org/swagger.json", "org");
                c.SwaggerEndpoint("/swagger/sys/swagger.json", "sys");
                c.RoutePrefix = string.Empty;// �ڸ�Ŀ¼�ṩSwagger UI
                c.DocumentTitle = ""; // �ĵ�����
                //c.InjectStylesheet("/swagger-ui/custom.css");// ע���Զ���css
                c.DocExpansion(DocExpansion.None);// Ĭ�������ӿڷ���
            });
            #endregion
        }
    }
}
