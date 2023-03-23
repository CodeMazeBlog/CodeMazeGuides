using Microsoft.AspNetCore.Mvc;

namespace TestingILogger.Controllers
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

        [HttpGet("[action]")]
        public IEnumerable<WeatherForecast> GetForecastInfo()
        {
            _logger.LogInformation("WeatherForecastController: Severity - Information");

            return Enumerable
                .Range(1, 5)
                .Select(index =>
                        new WeatherForecast
                        {
                            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index).Date),
                            TemperatureC = Random.Shared.Next(-20, 55),
                            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                        }
                ).ToArray();
        }

        [HttpGet("[action]")]
        public IEnumerable<WeatherForecast> GetForecastError()
        {
            _logger.LogError("WeatherForecastController: Severity - Error");

            return Enumerable
                .Range(1, 5)
                .Select(index =>
                        new WeatherForecast
                        {
                            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                            TemperatureC = Random.Shared.Next(-20, 55),
                            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                        }
                ).ToArray();
        }
    }
}