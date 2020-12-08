using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.CorrelationId.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SamplePollyController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SamplePollyController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> SomeAction()
        {
            // Get an HttpClient configured to the specification you defined in StartUp.
            var client = _httpClientFactory.CreateClient("GitHub");

            return Ok(await client.GetStringAsync("/someapi"));
        }
    }
}
