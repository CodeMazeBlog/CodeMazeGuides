using FuncActionDelegatesInCSharp.UseCases.CalculatorUseCase;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace FuncActionDelegatesInCSharpTests;

public class CalculatorTests
{
    [Theory]
    [InlineData(20, 10, Operand.Add, 30)]
    [InlineData(20, 10, Operand.Subtract, 10)]
    [InlineData(20, 10, Operand.Multiply, 200)]
    public void Run_Should_OperandTwoNumbers_When_UserEntersTwoNumbers_And_SelectOperand(
        int firstUserInput, int secondUserInput, int operand, int expectedResult)
    {
        // Arrange
        var expectedMessage = $"Result: {expectedResult}";
        var loggerMock = new Mock<ILogger<Calculator>>();
        var ioHandlerMock = new Mock<IIoHandler>();
        var sut = new Calculator(ioHandlerMock.Object, loggerMock.Object);

        ioHandlerMock.SetupSequence(x => x.GetUserInput())
            .Returns(firstUserInput)
            .Returns(secondUserInput)
            .Returns(operand);
        
        // Act
        sut.Run();

        // Assert
        loggerMock.Verify(x => x.Log(
            LogLevel.Information,
            It.IsAny<EventId>(),
            It.Is<It.IsAnyType>((v, t) => v.ToString() == expectedMessage),
            It.IsAny<Exception>(),
            It.IsAny<Func<It.IsAnyType, Exception, string>>()!
        ), Times.Once);
    }
}

public abstract class Operand
{
    public const int Add = 1;
    public const int Subtract = 2;
    public const int Multiply = 3;
}