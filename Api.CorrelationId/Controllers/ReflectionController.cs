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
using Newtonsoft.Json;

namespace Api.CorrelationId.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReflectionController : ControllerBase
    {
        private readonly IReflectionService _service;
        private readonly ILogger<ReflectionController> _logger;

        public ReflectionController(ILogger<ReflectionController> logger, IReflectionService service)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            
            return _service.ReturnAllStrings(new SampleReflectedClass());
        }


        [HttpGet("dictionary")]
        public string GetDictionary()
        {
           
            return JsonConvert.SerializeObject(_service.ReturnOnlyDictionary(new SampleReflectedClass()));
        }

        [HttpGet("eventids")]
        public string GetEventIds()
        {
           
            return JsonConvert.SerializeObject(_service.ReturnOnlyEventIds(new SampleReflectedClass()));
        }

        [HttpGet("optimised")]
        public string GetOptimised()
        {
            var optLogger = new ClassUsingOptimisedLogging(_logger);
            optLogger.LogOnceTwoParams("first", 200);

            return "";
        }

        [HttpGet("standard")]
        public string GetStandard()
        {
            var stdLogger = new ClassUsingStandardLogging(_logger);
            stdLogger.LogOnceOneParam("FiRsT");

            return JsonConvert.SerializeObject(_service.ReturnOnlyDictionary(stdLogger));
        }
    }
}
