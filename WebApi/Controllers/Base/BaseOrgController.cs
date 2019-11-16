using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApi.Controllers
{
    [ApiExplorerSettings(GroupName = "org")]
    public class BaseOrgController : BaseController
    {
        public BaseOrgController(ILogger<WeatherForecastController> logger) : base(logger)
        { }
    }
}