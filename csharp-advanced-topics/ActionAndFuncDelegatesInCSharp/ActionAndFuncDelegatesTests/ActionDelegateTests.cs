using System;
using System.IO;
using Xunit;

public class ActionDelegatesTests
{
    [Fact]
    public void TestLogger()
    {
        // Arrange
        var log1 = "Info1";
        var log2 = "Info2";

        // Act
        var result = CaptureConsoleOutput(() => ActionDelegates.Logger(log1, log2));

        // Assert
        Assert.Equal($"This logs stuff to the console. Example: {log1}, \n {log2}", result);
    }

    private string CaptureConsoleOutput(Action action)
    {
        using (var consoleOutput = new StringWriter())
        {
            Console.SetOut(consoleOutput);
            action.Invoke();
            return consoleOutput.ToString().Trim();
        }
    }
}
