using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Utility.Swagger
{
    /// <summary>
    /// swagger 添加头信息
    /// </summary>
    public class HeaderOperation : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            //if (operation.Parameters == null) operation.Parameters = new List<IParameter>();
            //var attrs = context.ApiDescription.ActionDescriptor.AttributeRouteInfo;

            ////先判断是否是匿名访问,
            //var descriptor = context.ApiDescription.ActionDescriptor as ControllerActionDescriptor;
            //if (descriptor != null)
            //{
            //    var actionAttributes = descriptor.MethodInfo.GetCustomAttributes(inherit: true);
            //    bool isAnonymous = actionAttributes.Any(a => a is AllowAnonymousAttribute);
            //    //非匿名的方法,链接中添加userHeader值
            //    if (!isAnonymous)
            //    {
            //        operation.Parameters.Add(new NonBodyParameter()
            //        {
            //            Name = "userHeader",
            //            In = "header",//query header body path formData
            //            Type = "string",
            //            Required = false //是否必选
            //        });
            //    }
            //}
        }
    }
}
