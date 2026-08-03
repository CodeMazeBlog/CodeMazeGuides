using Microsoft.Extensions.Logging.Abstractions;
using StyleCop.Controllers;
using Xunit;

namespace Tests
{
    public class WeatherForecastControllerTests
    {
        [Fact]
        public void WhenWeatherForecastControllerGetMethodIsCalled_ThenReturnsFiveElements()
        {
            // Arrange
            var loggerMock = new NullLogger<WeatherForecastController>();
            var controller = new WeatherForecastController(loggerMock);

            // Act
            var result = controller.Get();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(5, result.Count());
        }
    }
}