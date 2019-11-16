using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApi.Controllers
{
    /// <summary>
    /// WeatherForecast系统接口
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    //[ApiExplorerSettings(GroupName = "v2")]、、
    //[ApiExplorerSettings(IgnoreApi = true)]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        /// <summary>
        /// 注入日志
        /// </summary>
        /// <param name="logger"></param>
        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            this._logger = logger;
        }

        /// <summary>
        /// get接口
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
