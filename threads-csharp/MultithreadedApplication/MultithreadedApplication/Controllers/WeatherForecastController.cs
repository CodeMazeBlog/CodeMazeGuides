using Microsoft.AspNetCore.Mvc;

namespace MultithreadedApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        // Get weather method
        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IEnumerable<WeatherForecast>> GetWeather()
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


        // Generate random data
        private IEnumerable<WeatherForecast> GenerateRandomWeather()
        {
            string[] Summaries = new[] { "Freezing", "Bracing", "Chilly", "Cool" };

            Thread.Sleep(5);

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
           .ToArray();
        }

        private void LogWeatherData(IEnumerable<WeatherForecast> wheaterList)
        {
            foreach (var item in wheaterList)
            {
                Thread.Sleep(5);
                _logger.LogInformation("Temperature: " + item.TemperatureC.ToString());
            }
        }
    }
}