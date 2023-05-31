
using Microsoft.Extensions.Logging;
using RollingFileLoggingWithSerilog.Controllers;
using Serilog;

namespace Tests
{
    public class RollingFileLoggingWithSerilogUnitTest
    {
        [Fact]
        public void WhenLogMessage_ThenMessageShouldWriteToFile()
        {
            // Arrange
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddSerilog();
            });

            var logger = loggerFactory.CreateLogger<HomeController>();
            var controller = new HomeController(logger);

            var logMessage = "Test log message";

            //Act
            var result = controller.Index(logMessage);

            //Assert
            var logFileContent = File.ReadAllText("log.txt");
            Assert.Contains(logMessage, logFileContent);

        }
    }
}