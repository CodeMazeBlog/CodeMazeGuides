using Microsoft.Extensions.Logging;
using Moq;
using RollingFileLoggingWithSerilog.Controllers;

namespace Tests
{
    public class RollingFileLoggingWithSerilogUnitTest
    {
        [Fact]
        public void WhenLogMessage_ThenMessageShouldWriteToFile()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<HomeController>>();
            var controller = new HomeController(loggerMock.Object);

            //Act
            controller.Index();

            //Assert
            loggerMock.Verify(
                x => x.Log(
                LogLevel.Information,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => true),
                It.IsAny<Exception>(),
                It.Is<Func<It.IsAnyType, Exception, string>>((v, t) => true)),
                Times.Once);
        }
    }
}