namespace Tests;

public class HandleFuncDelegateTests
{
    [Fact]
    public void PrintFuncDelegate_PrintsResultToConsole()
    {
        // Arrange
        StringWriter consoleOutput = new StringWriter();
        Console.SetOut(consoleOutput);

        // Act
        HandleFuncDelegate.PrintFuncDelegate();

        // Assert
        Assert.Equal($"\nResult = 40{Environment.NewLine}", consoleOutput.ToString());
    }
}

public class HandleFuncDelegate
{
    public static int Add(int a, int b)
    {
        return a + b;
    }

    public static void PrintFuncDelegate()
    {
        Func<int, int, int> AddNumbers = Add;
        var result = Add(10, 30);
        Console.WriteLine($"\nResult = {result}");
    }
}
