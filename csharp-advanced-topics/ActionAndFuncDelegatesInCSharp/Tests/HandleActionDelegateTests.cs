namespace Tests;

public class HandleActionDelegateTests
{
    [Fact]
    public void PrintNumber_PrintsCorrectResult()
    {
        StringWriter sw = new StringWriter();
        Console.SetOut(sw);

        HandleActionDelegate.PrintActionDelegate();
        string output = sw.ToString().Trim();

        Assert.Equal("Result = 2", output);
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
