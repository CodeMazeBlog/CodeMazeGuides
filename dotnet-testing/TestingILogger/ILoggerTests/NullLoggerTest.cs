using Microsoft.Extensions.Logging.Abstractions;
using TestingILogger.Controllers;

namespace ILoggerTests
{
    public class NullLoggerTest
    {
        private readonly WeatherForecastController _forecastController;

        public NullLoggerTest()
        {
            var logger = new NullLogger<WeatherForecastController>();
            _forecastController = new WeatherForecastController(logger);
        }

        [Fact]
        public void WhenGettingForecastInfo_ThenLogsInformationLog()
        {
            //Act
            var response = _forecastController.GetForecastInfo();

            //Assert
            Assert.NotEmpty(response);
        }

        [Fact]
        public void WhenGettingForecastError_ThenLogsErrorLog()
        {
            //Act
            var response = _forecastController.GetForecastError();

            //Assert
            Assert.NotEmpty(response);
        }
    }
}