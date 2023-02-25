using ActionAndFuncDelegatesInCSharp;

namespace Tests;

public class HandleFuncDelegateTests
{
    [Fact]
    public void PrintFuncDelegate_PrintsResultToConsole()
    {
        StringWriter consoleOutput = new StringWriter();
        Console.SetOut(consoleOutput);

        HandleFuncDelegate.PrintFuncDelegate();

        Assert.Equal($"\nResult = 40{Environment.NewLine}", consoleOutput.ToString());
    }
}
