using ActionAndFuncDelegatesInCSharp;

namespace Tests;

public class HandleActionDelegateTest
{
    [Fact]
    public void PrintNumber_WhenGivenNumber_ThenPrintTheResult()
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
