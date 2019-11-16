using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApi.Controllers
{
    [ApiExplorerSettings(GroupName = "sys")]
    public class BaseSysController : BaseController
    {
        public BaseSysController(ILogger<WeatherForecastController> logger) : base(logger)
        { }
    }
}