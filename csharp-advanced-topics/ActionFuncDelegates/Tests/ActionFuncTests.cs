namespace Tests;

public class ActionFuncTests
{
    [Fact]
    public void ActionDelegate_PrintsMessage()
    {
        // Arrange
        var consoleOutput = new System.IO.StringWriter();
        Console.SetOut(consoleOutput);

        // Act
        Program.ExecuteActionDelegate();

        // Assert
        string expectedOutput = "Hello, Action!" + Environment.NewLine;
        Assert.Equal(expectedOutput, consoleOutput.ToString());
    }

    [Fact]
    public void FuncDelegate_AddsNumbers()
    {
        // Act
        int result = Program.ExecuteFuncDelegate();

        // Assert
        Assert.Equal(12, result);
    }
}