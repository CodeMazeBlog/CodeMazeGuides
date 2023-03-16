using ActionAndFuncDelegatesInCSharp;

namespace Tests;

public class HandleActionDelegateTests
{
    [Fact]
    public void PrintNumber_PrintsCorrectResult()
    {
        // Arrange
        var writer = new StringWriter();
        Console.SetOut(writer);

        // Act
        HandleActionDelegate.PrintNumber(2);

        // Assert
        var output = writer.GetStringBuilder().ToString().Trim();
        Assert.Equal("Result = 2", output);
    }
}
