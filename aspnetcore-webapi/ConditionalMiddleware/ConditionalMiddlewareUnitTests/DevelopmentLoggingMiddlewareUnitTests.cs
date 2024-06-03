using ConditionalMiddleware;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ConditionalMiddlewareUnitTests;

[TestClass]
public class DevelopmentLoggingMiddlewareUnitTests
{
    [TestMethod]
    public async Task GivenARequest_WhenMiddlewareIsInvoked_ThenLogsInformation()
    {
        // Arrange
        var loggerMock = new Mock<ILogger<DevelopmentLoggingMiddleware>>();
        var nextMock = new Mock<RequestDelegate>();

        var context = new DefaultHttpContext();
        context.Request.Path = "/test-path";

        nextMock.Setup(next => next(It.IsAny<HttpContext>())).Returns(Task.CompletedTask);

        var middleware = new DevelopmentLoggingMiddleware(nextMock.Object, loggerMock.Object);

        // Act
        await middleware.InvokeAsync(context);

        // Assert
        loggerMock.Verify(
            logger => logger.Log(
                LogLevel.Information,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => v!.ToString()!.Contains("Handling request: /test-path")),
                It.IsAny<Exception>(),
                It.Is<Func<It.IsAnyType, Exception, string>>((v, t) => true)),
            Times.Once);

        loggerMock.Verify(
            logger => logger.Log(
                LogLevel.Information,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => v!.ToString()!.Contains("Finished handling request.")),
                It.IsAny<Exception>(),
                It.Is<Func<It.IsAnyType, Exception, string>>((v, t) => true)),
            Times.Once);
    }
}
