using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Api.CorrelationId.Interfaces;
using Api.CorrelationId.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.CorrelationId.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherService _service;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherService service)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            _logger.LogInformation("GET - Started");
            return _service.DoSomething();
        }

        [HttpGet("another")]
        public IEnumerable<WeatherForecast> GetAnother()
        {
            _logger.LogInformation("GET ANOTHER - Started");
            return _service.DoSomething();
        }

        
    }
}
