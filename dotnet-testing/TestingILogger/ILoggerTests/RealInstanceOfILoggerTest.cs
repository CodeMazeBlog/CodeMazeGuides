using Microsoft.Extensions.Logging;
using TestingILogger.Controllers;

namespace ILoggerTests
{
    public class RealInstanceOfILoggerTest
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly WeatherForecastController _controller;
        private readonly StringWriter _stringWriter;

        public RealInstanceOfILoggerTest()
        {
            _stringWriter = new StringWriter();
            Console.SetOut(_stringWriter);

            using var loggerFactory = LoggerFactory.Create(c => c.AddConsole());
            _logger = loggerFactory.CreateLogger<WeatherForecastController>();
            _controller = new WeatherForecastController(_logger);
        }

        [Fact]
        public void WhenGettingForecastInfo_ThenLogsInformationLog()
        {
            //Act
            var response = _controller.GetForecastInfo();

            //Assert
            var logMessage = _stringWriter.ToString();
            
            Assert.NotEmpty(response);
            Assert.Contains("WeatherForecastController: Severity - Information", logMessage);
        }

        [Fact]
        public void WhenGettingForecastError_ThenLogsErrorLog()
        {
            var response = _controller.GetForecastError();

            //Assert
            var logMessage = _stringWriter.ToString();
            
            Assert.NotEmpty(response);
            Assert.Contains("WeatherForecastController: Severity - Error", logMessage);
        }
    }
}