using Application;

namespace Tests;

public class ActionAndFuncDelegatesUnitTest : IDisposable
{
    private readonly StringWriter _output = new();

    public ActionAndFuncDelegatesUnitTest()
    {
        Console.SetOut(_output);
    }

    public void Dispose()
    {
        _output.Dispose();
        GC.SuppressFinalize(this);
    }

    private string[] PrintedOutputToArray()
    {
        var printedString = _output.ToString();

        return printedString.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
    }

    [Fact]
    public void WhenPrintNumbersUsingActionDelegate_ThenPrintNumbers()
    {
        Program.PrintNumbersUsingActionDelegate();

        var numbers = PrintedOutputToArray();

        Assert.Equal(5, numbers.Length);
        Assert.Equal(new string[]
        {
                "1","2","3","4","5"
        }, numbers);
    }

    [Fact]
    public void WhenPrintFullNamesUsingFuncDelegate_ThenPrintFullNames()
    {
        Program.PrintFullNamesUsingFuncDelegate();

        var fullNames = PrintedOutputToArray();

        Assert.Equal(3, fullNames.Length);
        Assert.Equal(new string[]
        {
                "Tony James","Terry John","Telly Carter"
        }, fullNames);
    }
}