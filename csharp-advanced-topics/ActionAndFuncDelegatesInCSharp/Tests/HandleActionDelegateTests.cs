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

public class HandleActionDelegate
{
    public delegate void Print(int result);

    public static void PrintNumber(int a)
    {
        Console.WriteLine($"\nResult = {a}");
    }

    public static void PrintActionDelegate()
    {
        Print print = PrintNumber;
        print(2);
    }
}
