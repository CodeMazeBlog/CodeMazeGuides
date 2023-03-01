using ActionAndFuncDelegatesInCSharp;

namespace Tests;

public class HandleFuncDelegateTests
{
    [Fact]
    public void PrintFuncDelegate_PrintsResultToConsole()
    {
        var result = HandleFuncDelegate.PrintFuncDelegate();

        // Assert
        Assert.Equal($"\nResult = 40{Environment.NewLine}", result);
    }
}
