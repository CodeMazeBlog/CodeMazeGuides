using FuncActionDelegatesInCSharp.UseCases;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace FuncActionDelegatesInCSharpTests;

public class ActionDelegateUseCaseTests
{
    [Fact]
    public void Run_Should_LogInformation()
    {
        // Arrange
        var loggerMock = new Mock<ILogger<ActionDelegateUseCase>>();
        var sut = new ActionDelegateUseCase(loggerMock.Object);

        // Act
        sut.Run();

        // Assert
        loggerMock.Verify(x => x.Log(
            LogLevel.Information,
            It.IsAny<EventId>(),
            It.Is<It.IsAnyType>((v, t) => v.ToString() == "Welcome to amazing Code-Maze"),
            It.IsAny<Exception>(),
            It.IsAny<Func<It.IsAnyType, Exception, string>>()!
        ), Times.Once);
    }
}