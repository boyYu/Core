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
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // Autofac

            #region Swagger
            services.AddSwaggerGen(options =>
            {
                // v1 ���飬��Ӧ����[ApiExplorerSettings(GroupName = "v1")]
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = Configuration.GetSection("Swagger:Title").Value,
                    Version = Configuration.GetSection("Swagger:Version").Value,
                    Description = Configuration.GetSection("Swagger:Description").Value
                });
                // ����XMLע���е�����
                DirectoryInfo d = new DirectoryInfo(AppContext.BaseDirectory);
                FileInfo[] files = d.GetFiles("*.xml");
                foreach (var item in files)
                {
                    options.IncludeXmlComments(item.FullName);
                }
                options.IgnoreObsoleteActions();// ���� ��Ӧ����[ApiExplorerSettings(IgnoreApi = true)]

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
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.SwaggerEndpoint("/swagger/v2/swagger.json", "My API V1");// �г����Swagger�ĵ�
                c.RoutePrefix = string.Empty;// �ڸ�Ŀ¼�ṩSwagger UI
                c.DocumentTitle = ""; // �ĵ�����
                c.InjectStylesheet("/swagger-ui/custom.css");// ע���Զ���css
            });
            #endregion
        }
    }
}
