using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MultithreadedApplication.Controllers;

namespace Tests
{
    public class MultiThreadedWeatherTests
    {
        [Fact]
        public async Task WhenCallingWeatherController_ThenItReturnsData()
        {
            // Arrange
            var serviceProvider = new ServiceCollection()
                                    .AddLogging()
                                    .BuildServiceProvider();

            var factory = serviceProvider.GetService<ILoggerFactory>();

            var logger = factory.CreateLogger<WeatherForecastController>();

            var controller = new WeatherForecastController(logger);

            var weather = await controller.GetWeather();
            Assert.NotNull(weather);
        }
    }
}