using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        private  ILogger<WeatherForecastController> _logger;

        /// <summary>
        /// 注入日志
        /// </summary>
        /// <param name="logger"></param>
        public BaseController(ILogger<WeatherForecastController> logger)
        {
            this._logger = logger;
        }
    }
}