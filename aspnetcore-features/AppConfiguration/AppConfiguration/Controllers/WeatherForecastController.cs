using Microsoft.AspNetCore.Mvc;

namespace AppConfiguration.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {



        private readonly IConfiguration _configuration;

        public WeatherForecastController(IConfiguration configuration)
        {

            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var from = _configuration.GetValue<string>("EmailConfiguration:From");
            var to = _configuration.GetValue<string>("EmailConfiguration:To");
            var subject = _configuration.GetValue<string>("EmailConfiguration:Subject");


            return Ok($"Send email to {to} from {from} subject {subject}");
        }


    }
}