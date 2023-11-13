using Microsoft.AspNetCore.Mvc;

namespace MultithreadedApplication.Controllers
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

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            IEnumerable<WeatherForecast> returnedData = new List<WeatherForecast>();

            await Task.Run(() =>
            {
                returnedData = GenerateRandomWeather();
            });

            Thread thread1 = new Thread(() => LogWeatherData(returnedData))
            {
                Name = "Log Thread One"
            };
            Thread thread2 = new Thread(() => LogWeatherData(returnedData))
            {
                Name = "Log Thread Two"
            };
            thread1.Start();
            thread2.Start();

            return returnedData;
        }

        private IEnumerable<WeatherForecast> GenerateRandomWeather()
        {
            Thread.Sleep(3000);
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
           .ToArray();
        }

        public static void LogWeatherData(IEnumerable<WeatherForecast> wheaterList)
        {
            foreach (var item in wheaterList)
            {
                Thread.Sleep(100);
                Console.WriteLine(item.TemperatureC);
            }
        }
    }
}