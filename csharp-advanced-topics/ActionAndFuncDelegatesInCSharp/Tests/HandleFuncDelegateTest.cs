namespace Tests;

public class HandleFuncDelegateTest
{
    [Fact]
    public void Add_ReturnsCorrectSum()
    {
        int expected = 5;
        
        int actual = HandleFuncDelegate.Add(2, 3);
        
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void PrintFuncDelegate_CallsAddAndPrintsResult()
    {
        StringWriter sw = new StringWriter();
        Console.SetOut(sw);
        int expected = 40;

        HandleFuncDelegate.PrintFuncDelegate();
        string output = sw.ToString().Trim();
        int actual = int.Parse(output.Substring(output.LastIndexOf(' ') + 1));

        Assert.Equal(expected, actual);
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
