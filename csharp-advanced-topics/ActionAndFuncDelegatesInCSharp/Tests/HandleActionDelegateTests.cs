using ActionAndFuncDelegatesInCSharp;

namespace Tests;

public class HandleActionDelegateTests
{
    [Fact]
    public void PrintActionDelegate_PrintsResultToConsole()
    {
        StringWriter consoleOutput = new StringWriter();
        Console.SetOut(consoleOutput);
        HandleActionDelegate.PrintActionDelegate();
        Assert.Equal($"\nResult = 2{Environment.NewLine}", consoleOutput.ToString());
    }
}
