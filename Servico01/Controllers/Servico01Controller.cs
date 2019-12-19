using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Servico01.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Servico01Controller : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "A", "B", "C", "D", "E", "F", "G", "H", "I", "J"
        };

        private readonly ILogger<Servico01Controller> _logger;

        public Servico01Controller(ILogger<Servico01Controller> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Index()
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

        [HttpGet("Integracao")]
        public async Task<IActionResult> Integracao()
        {
            using var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("http://servico02/servico02");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            return Content(responseBody, "application/json", Encoding.UTF8); 
            //return Json(responseBody, JsonRequestBehavior.AllowGet);

        }
    }
}
