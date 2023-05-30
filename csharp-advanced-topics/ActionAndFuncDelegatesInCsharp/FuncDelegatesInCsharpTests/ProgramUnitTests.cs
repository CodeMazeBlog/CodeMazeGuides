namespace FuncDelegatesInCsharpTests;

public class ProgramUnitTests
{
    private string CaptureConsoleOutput(Action action)
    {
        using var writer = new StringWriter();
        Console.SetOut(writer);
        action();
        return writer.ToString().Trim();
    }

    [Fact]
    public void WhenInvokingAdd_ThenReturnSum()
    {
        // Arrange
        Func<int, int, int> add = (a, b) => a + b;

        // Act
        int result = add(2, 3);

        // Assert
        Assert.Equal(5, result);
    }

    [Fact]
    public void WhenPrintingSum_ThenPrintReturnValueOfGivenFunc()
    {
        // Arrange
        var consoleOutput = "5";
        Func<int, int, int> add = (a, b) => a + b;

        // Act
        var output = CaptureConsoleOutput(() => FuncDelegatesInCsharp.Program.PrintSum(add));

        // Assert
        Assert.Equal(consoleOutput, output);
    }

    [Fact]
    public void WhenPrintingSumWithTwoInts_ThenPrintReturnValueOfGivenFuncWithTwoInts()
    {
        // Arrange
        var consoleOutput = "5";
        Func<int, int, int> add = (a, b) => a + b;

        // Act
        var output = CaptureConsoleOutput(() => FuncDelegatesInCsharp.Program.PrintSum(2, 3, add));

        // Assert
        Assert.Equal(consoleOutput, output);
    }

    [Fact]
    public void WhenAddingTwoInts_ThenReturnSum()
    {
        // Arrange

        // Act
        int result = FuncDelegatesInCsharp.Program.Add(2, 3);

        // Assert
        Assert.Equal(5, result);
    }
}
