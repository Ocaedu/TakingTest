using Microsoft.AspNetCore.Mvc;

namespace TakingTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SalesController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public SalesController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "Teste")]
        public string Get()
        {
            return "Teste";
        }



    }
}
