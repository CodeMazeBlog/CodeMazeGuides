using Microsoft.AspNetCore.Mvc;

namespace OptionalParameterinWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Id = index,
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[index]
            })
            .ToArray();
        }

        [HttpGet("GetById/{id?}")]
        public WeatherForecast GetById(int id = 1)
        {
            var forecasts = Get();

            var weatherForecast = forecasts.Where(w => w.Id == id).FirstOrDefault()!;

            return weatherForecast;
        }
    }
}