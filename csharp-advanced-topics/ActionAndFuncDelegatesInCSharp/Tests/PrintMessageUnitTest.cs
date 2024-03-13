using ActionAndFuncDelegatesInCSharp;
using Xunit;

namespace Tests;
public class PrintMessageUnitTest
{
    [Fact]
    public void WhenPrintMessageIsCalled_ThenCorrectMessageIsPrintedToConsole()
    {
        // Arrange
        var expectedOutput = $"Hello, code maze, this is an action delegate!{Environment.NewLine}";
        using var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        Program.PrintMessage("Hello, code maze, this is an action delegate!");

        // Assert
        var output = stringWriter.ToString();
        Assert.Equal(expectedOutput, output);
    }   
}
