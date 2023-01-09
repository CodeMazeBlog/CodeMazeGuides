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
        var two = Program.AddOneWithFunc();

        Assert.Equal(2, two);
    }

    [Fact]
    public void WhenAddingNumbersWithFunc_ThenCorrectResultReturned()
    {
        var three = Program.AddNumbersWithFunc();

        Assert.Equal(3, three);
    }

    [Fact]
    public void WhenAddingOneWithCustomFunc_ThenCorrectResultReturned()
    {
        var two = Program.AddOneWithCustomFunc();

        Assert.Equal(2, two);
    }   
}