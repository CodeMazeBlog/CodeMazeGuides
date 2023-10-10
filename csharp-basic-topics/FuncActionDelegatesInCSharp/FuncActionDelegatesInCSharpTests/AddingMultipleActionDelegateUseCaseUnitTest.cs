using FuncActionDelegatesInCSharp.UseCases;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace FuncActionDelegatesInCSharpTests;

public class AddingMultipleActionDelegateUseCaseUnitTest
{
    [Fact]
    public void GivenRunMethod_WhenIsCalled_ThenInvokeAllActions()
    {
        // Arrange
        var loggerMock = new Mock<ILogger<AddingMultiplyActionDelegateUseCase>>();
        var sut = new AddingMultiplyActionDelegateUseCase(loggerMock.Object);

        // Act
        sut.Run();

        // Assert
        loggerMock.Verify(x => x.Log(
            LogLevel.Information,
            It.IsAny<EventId>(),
            It.Is<It.IsAnyType>((v, t) => v.ToString() == "Action1: This is the first task."),
            It.IsAny<Exception>(),
            It.IsAny<Func<It.IsAnyType, Exception, string>>()!
        ), Times.Once);
        
        loggerMock.Verify(x => x.Log(
            LogLevel.Information,
            It.IsAny<EventId>(),
            It.Is<It.IsAnyType>((v, t) => v.ToString() == "Action2: This is the second task."),
            It.IsAny<Exception>(),
            It.IsAny<Func<It.IsAnyType, Exception, string>>()!
        ), Times.Once);
        
        loggerMock.Verify(x => x.Log(
            LogLevel.Information,
            It.IsAny<EventId>(),
            It.Is<It.IsAnyType>((v, t) => v.ToString() == "Action3: This is the third task."),
            It.IsAny<Exception>(),
            It.IsAny<Func<It.IsAnyType, Exception, string>>()!
        ), Times.Once);
    }
}