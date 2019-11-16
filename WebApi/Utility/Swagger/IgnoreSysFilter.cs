using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Linq;
using System.Reflection;

namespace WebApi.Utility.Swagger
{

    /// <summary> 
    /// 隐藏接口，不生成到swagger文档展示 
    /// </summary> 
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public partial class IgnoreSysAttribute : Attribute { }

    /// <summary>
    /// 隐藏sys的接口
    /// </summary>
    public class IgnoreSysFilter : IDocumentFilter
    {
        /// <summary>
        /// 实现Apply方法
        /// </summary>
        /// <param name="swaggerDoc"></param>
        /// <param name="context"></param>
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            //foreach (ApiDescription apiDescription in context.ApiDescriptions)
            //{
            //    var c = apiDescription;
            //    if (apiDescription.GroupName != "sys")
            //    {
            //        swaggerDoc.Paths.Remove("/" + apiDescription.RelativePath);
            //    }
            //}
        }
    }
}
