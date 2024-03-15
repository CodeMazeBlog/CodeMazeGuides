using HowToSolveTRequestCannotBeTypeParameter.PipelineBehaviour;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace HowToSolveTRequestCannotBeTypeParameterTests;

public class LoggingPipelineTests
{
    public class TestRequest { }
    public class TestResponse { }

    [Fact]
    public async Task WhenLoggingPipelineIsInovked_ThenLogsCorrectRequestAndResponse()
    {
        // Arrange
        var request = new TestRequest();
        var response = new TestResponse();
        var cancellationToken = CancellationToken.None;

        var loggerMock = new Mock<ILogger<LoggingPipelineBehaviour<TestRequest, TestResponse>>>();
        var loggingBehaviour = new LoggingPipelineBehaviour<TestRequest, TestResponse>(loggerMock.Object);

        Task<TestResponse> Next() => Task.FromResult(response);

        // Act
        var result = await loggingBehaviour.Handle(request, Next, cancellationToken);

        // Assert
        loggerMock.Verify(l =>
                l.Log(LogLevel.Information,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, _) => v.ToString().Contains("Handling")),
                    It.IsAny<Exception>(),
                    It.IsAny<Func<It.IsAnyType, Exception?, string>>()
                ), Times.Once);

        loggerMock.Verify(l =>
                l.Log(LogLevel.Information,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, _) => v.ToString().Contains("Handled")),
                    It.IsAny<Exception>(),
                    It.IsAny<Func<It.IsAnyType, Exception?, string>>()
                ), Times.Once);

        Assert.Equal(response, result);
    }
}