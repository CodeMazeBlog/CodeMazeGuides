using Xunit;

namespace Tests;
public class PrintMessageUnitTest
{
    [Fact]
    public void WhenPrintMessageIsCalled_ThenCorrectMessageIsPrintedToConsole()
    {
        // Arrange
        var expectedMessage = "Hello code maze, this is an action delegate!";
        using var consoleOutput = new StringWriter();
        Console.SetOut(consoleOutput);

        Action<string> printAction = PrintMessage;

        // Act
        printAction(expectedMessage);

        // Assert
        Assert.Equal(expectedMessage + Environment.NewLine, consoleOutput.ToString());
    }

    private void PrintMessage(string message)
    {
        Console.WriteLine(message);
    }
}
