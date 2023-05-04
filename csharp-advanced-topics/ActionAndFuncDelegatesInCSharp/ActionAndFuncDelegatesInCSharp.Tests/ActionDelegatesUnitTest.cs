namespace ActionAndFuncDelegatesInCSharp.Tests;

public class ActionDelegatesUnitTest : IDisposable
{

    public void Dispose()
    {
    }

    [Fact]
    public void When_AddNumbersCalled_Then_DisplaySum()
    {
        // Arrange
        Action<int, int> addNumbers = ActionDelegates.AddNumbers;
        var consoleOutput = new StringWriter();
        Console.SetOut(consoleOutput);
        // Act
        addNumbers(1, 10);

        // Assert
        string expectedResult = "The sum is: 11";
        string actualResult = consoleOutput.ToString().TrimEnd();
        Assert.Equal(expectedResult, actualResult);
    }
}