using Microsoft.AspNetCore.Mvc;

namespace AccountOwnerServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastWithILoggerController : ControllerBase
    {
        private readonly ILogger<WeatherForecastWithILoggerController> _logger;

        public WeatherForecastWithILoggerController(ILogger<WeatherForecastWithILoggerController> logger)
        {
            _logger = logger;
        }

        // The platform way: no registration, and the message is a template with a named
        // placeholder. WeatherForecastController takes the ILoggerManager wrapper instead,
        // and both reach the same file because NLog is registered as a provider.
        [HttpGet]
        public IEnumerable<string> Get()
        {
            _logger.LogInformation("Serving {Count} forecast values", 2);

            return ["value1", "value2"];
        }
    }
}
