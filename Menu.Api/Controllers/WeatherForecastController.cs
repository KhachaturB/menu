using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Menu.Api.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Menu.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

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

        [HttpGet("test")]
        [AllowAnonymous]
        public TestDto GetTest()
        {
            return new TestDto
            {
                Name = "Olololo",
                Url = "https://sun1-23.userapi.com/impf/c624316/v624316949/2a15c/zdLxLW5PlSQ.jpg?size=604x594&quality=96&sign=e779e94e069903e2858d340d6a40f2e5&type=album"
            };
        }
    }
}
