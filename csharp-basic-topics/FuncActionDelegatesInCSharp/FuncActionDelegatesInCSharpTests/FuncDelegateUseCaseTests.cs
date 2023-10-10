using FuncActionDelegatesInCSharp.UseCases;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace FuncActionDelegatesInCSharpTests;

public class FuncDelegateUseCaseTests
{
    [Theory]
    [InlineData(10, 20, 30, 200)]
    public void Run_Should_AddAndMultiplyTwoNumbers_when_GivenTwoNumbers(
        int firstNumber, int secondNumber, int expectedAddResult, int expectedMultiplyResult)
    {
        // Arrange
        var loggerMock = new Mock<ILogger<FuncDelegateUseCase>>();
        var sut = new FuncDelegateUseCase(loggerMock.Object);

        // Act
        sut.Run(firstNumber, secondNumber);

        // Assert
        loggerMock.Verify(x => x.Log(
            LogLevel.Information,
            It.IsAny<EventId>(),
            It.Is<It.IsAnyType>((v, t) 
                => v.ToString() == $"The adding result is: {expectedAddResult}"),
            It.IsAny<Exception>(),
            It.IsAny<Func<It.IsAnyType, Exception, string>>()!
        ), Times.Once);
        
        loggerMock.Verify(x => x.Log(
            LogLevel.Information,
            It.IsAny<EventId>(),
            It.Is<It.IsAnyType>((v, t) 
                => v.ToString() == $"The multiplying result is: {expectedMultiplyResult}"),
            It.IsAny<Exception>(),
            It.IsAny<Func<It.IsAnyType, Exception, string>>()!
        ), Times.Once);
    }
}