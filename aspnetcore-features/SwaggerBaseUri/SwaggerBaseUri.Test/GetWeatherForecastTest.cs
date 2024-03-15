using Microsoft.Extensions.Logging;
using Moq;
using SwaggerBaseUri.Controllers;
using Xunit;

namespace SwaggerBaseUri.Test
{
    public class GetWeatherForecastTest
    {
        [Fact]
        public void WhenGettingWeatherForecast_ThenItShouldReturnCorrectData()
        {
            // Arrange
            var mockLogger = new Mock<ILogger<WeatherForecastController>>();
            var controller = new WeatherForecastController(mockLogger.Object);

            // Act
            var result = controller.Get();

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Count() == 5);

            var firstItem = result.First();

            Assert.NotNull(firstItem);
            Assert.NotEqual(0, firstItem.TemperatureC);
            Assert.NotNull(firstItem.Summary);
        }
    }
}