using Microsoft.Extensions.Logging;
using Moq;
using MultithreadedApplication.Controllers;

namespace Tests
{
    public class MultiThreadedWeatherTests
    {
        private readonly WeatherForecastController _forecastController;
        private readonly Mock<ILogger<WeatherForecastController>> _mockLogger;
        public MultiThreadedWeatherTests()
        {
            // Arrange
            _mockLogger = new Mock<ILogger<WeatherForecastController>>();
            _forecastController = new WeatherForecastController(_mockLogger.Object);
        }

        [Fact]
        public async Task WhenCallingWeatherController_ThenItReturnsData()
        {
            // Act
            var weather = await _forecastController.GetWeather();

            // Assert
            Assert.NotNull(weather);
        }

        [Fact]
        public async Task WhenGettingForecastInfo_ThenLogsInformationLogAfterThreadSleep()
        {
            //Act
            var response = await _forecastController.GetWeather();
            Thread.Sleep(5000);

            //Assert
            Assert.NotEmpty(response);

            _mockLogger.Verify(l =>
             l.Log(LogLevel.Information,
                 It.IsAny<EventId>(),
                 It.Is<It.IsAnyType>((v, _) => v.ToString().Contains("Temperature")),
                 It.IsAny<Exception>(),
                 It.IsAny<Func<It.IsAnyType, Exception, string>>()
             ), Times.AtLeastOnce
            );
        }
    }
}