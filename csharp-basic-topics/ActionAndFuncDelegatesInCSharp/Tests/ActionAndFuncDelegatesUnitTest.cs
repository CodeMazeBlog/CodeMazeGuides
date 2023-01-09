using ActionAndFuncDelegatesInCSharp;

namespace Tests;

public class ActionAndFuncDelegatesUnitTest
{
    [Fact]
    public void WhenPrintingNumberWithAction_ThenCorrectResultPrinted()
    {
        using var outWriter = new StringWriter();
        Console.SetOut(outWriter);

        Program.PrintNumberWithAction();

        Assert.Equal("10", outWriter.ToString().Trim());
    }

    [Fact]
    public void WhenAddingOneWithFunc_ThenCorrectResultReturned()
    {
        var sum = Program.AddOneWithFunc();

        Assert.Equal(2, sum);
    }

    [Fact]
    public void WhenAddingNumbersWithFunc_ThenCorrectResultReturned()
    {
        var sum = Program.AddNumbersWithFunc();

        Assert.Equal(3, sum);
    }

    [Fact]
    public void WhenAddingOneWithCustomFunc_ThenCorrectResultReturned()
    {
        var sum = Program.AddOneWithCustomFunc();

        Assert.Equal(2, sum);
    }   
}