using Microsoft.AspNetCore.Mvc;

namespace RemoteHostIpAddress.Controllers
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
        private readonly IRemoteHostService _remoteHostService;

        public WeatherForecastController(
            ILogger<WeatherForecastController> logger,
            IRemoteHostService remoteHostService)
        {
            _logger = logger;
            _remoteHostService = remoteHostService;
        }

        [HttpGet(Name = "GetWeatherForecastData")]
        public IEnumerable<WeatherForecast> Get()
        {
            var remoteIpAddress = _remoteHostService.GetRemoteHostIpAddressUsingXRealIp(HttpContext);
            Console.WriteLine(remoteIpAddress);

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }).ToArray();
        }   
    }
}