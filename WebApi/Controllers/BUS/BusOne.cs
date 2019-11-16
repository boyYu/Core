using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    public class BusOne: BaseBusController
    {
        public BusOne(ILogger<WeatherForecastController> logger) : base(logger)
        { }

        /// <summary>
        /// get接口
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string Get()
        {
            return "moren";
        }

        /// <summary>
        /// 这是自己添加的
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetTwo")]
        public string GetTwo()
        {
            return "2";
        }
    }
}
