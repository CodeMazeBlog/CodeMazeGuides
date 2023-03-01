using ActionAndFuncDelegatesInCSharp;

namespace Tests;

public class HandleActionDelegateTests
{
    [Fact]
    public void PrintActionDelegate_PrintsResultToConsole()
    {
        var result = HandleActionDelegate.PrintActionDelegate();

        Assert.Equal($"\nResult = 2{Environment.NewLine}", result);
    }
}
