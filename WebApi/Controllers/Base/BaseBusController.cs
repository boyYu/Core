using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApi.Controllers
{
    [ApiExplorerSettings(GroupName = "bus")]
    public abstract class BaseBusController : BaseController
    {
        public BaseBusController(ILogger<WeatherForecastController> logger) : base(logger)
        { }
    }
}