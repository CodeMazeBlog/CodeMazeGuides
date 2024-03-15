using Microsoft.Extensions.Logging;
using Moq;
using TestingILogger.Controllers;

namespace ILoggerTests
{
    public class MockedLoggerTests
    {
        private readonly WeatherForecastController _forecastController;
        private readonly Mock<ILogger<WeatherForecastController>> _mockLogger;

        public MockedLoggerTests()
        {
            _mockLogger = new Mock<ILogger<WeatherForecastController>>();
            _forecastController = new WeatherForecastController(_mockLogger.Object);
        }

        [Fact]
        public void WhenGettingForecastInfo_ThenLogsInformationLog()
        {
            //Act
            var response = _forecastController.GetForecastInfo();

            //Assert
            Assert.NotEmpty(response);
            _mockLogger.Verify(l =>
                    l.Log(LogLevel.Information,
                        It.IsAny<EventId>(),
                        It.Is<It.IsAnyType>((v, _) => v.ToString().Contains("Info")),
                        It.IsAny<Exception>(),
                        It.IsAny<Func<It.IsAnyType, Exception, string>>()
                    ),Times.Once
            );
        }

        [Fact]
        public void WhenGettingForecastError_ThenLogsErrorLog()
        {
            //Act
            var response = _forecastController.GetForecastError();

            //Assert
            Assert.NotEmpty(response);
            _mockLogger.Verify(l =>
                    l.Log(LogLevel.Error,
                        It.IsAny<EventId>(),
                        It.Is<It.IsAnyType>((v, _) => v.ToString().Contains("Error")),
                        It.IsAny<Exception>(),
                        It.IsAny<Func<It.IsAnyType, Exception, string>>()
                    ),Times.Once
            );
        }
    }
}