using MediatRPipelineBehaviourError.MediaRPipelineBehaviour;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace MediatRPipelineBehaviourErrorTests;

public class LoggingPipelineTests
{
    [Fact]
    public async Task WhenLoggingPipelineIsInovked_ThenLogsCorrectRequestAndResponse()
    {
        // Arrange
        var request = new TestRequest();
        var response = new TestResponse();
        var cancellationToken = CancellationToken.None;

        var loggerMock = new Mock<ILogger<LoggingPipelineBehaviour<TestRequest, TestResponse>>>();
        var loggingBehaviour = new LoggingPipelineBehaviour<TestRequest, TestResponse>(loggerMock.Object);

        Task<TestResponse> next() => Task.FromResult(response);

        // Act
        var result = await loggingBehaviour.Handle(request, next, cancellationToken);

        // Assert
        loggerMock.Verify(l =>
                l.Log(LogLevel.Information,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, _) => v.ToString().Contains("Handling")),
                    It.IsAny<Exception>(),
                    It.IsAny<Func<It.IsAnyType, Exception, string>>()
                ), Times.Once
        );

        loggerMock.Verify(l =>
                l.Log(LogLevel.Information,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, _) => v.ToString().Contains("Handled")),
                    It.IsAny<Exception>(),
                    It.IsAny<Func<It.IsAnyType, Exception, string>>()
                ), Times.Once
        );

        Assert.Equal(response, result);
    }

    public class TestRequest { }
    public class TestResponse { }
}