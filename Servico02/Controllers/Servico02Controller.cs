using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Servico02.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Servico02Controller : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "1", "2", "2", "4", "5", "6", "7", "8", "9", "10"
        };

        private readonly ILogger<Servico02Controller> _logger;

        public Servico02Controller(ILogger<Servico02Controller> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Summary = Summaries[rng.Next(Summaries.Length)],
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55)                
            })
            .ToArray();
        }
    }
}
