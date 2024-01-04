using ActionAndFuncDelegates;

namespace Tests;

public class Tests
{
    [Fact]
    public void WhenGreetedWithName_ThenOutputsHelloWithName()
    {
        StringWriter sw = new();
        Console.SetOut(sw);

        Program.greet("Fred");

        var expectedOutput = "Hello, Fred!";
        var actualOutput = sw.ToString().Trim();

        Assert.Equal(expectedOutput, actualOutput);
    }

    [Fact]
    public void WhenMultiplyingNumbersAndMeasuringStringLength_ThenValidResultsReturned()
    {
        var product = Program.multiply(8, 5);
        var length = Program.stringLength("Love Func!");

        var expectedProduct = 8 * 5;
        var expectLength = 10;

        Assert.Equal(expectedProduct, product);

        Assert.Equal(expectLength, length);
    }

    [Fact]
    public void WhenPerformingSafeDivision_ThenHandlesDivisionGracefully()
    {
        var divisionResult = Program.safeDivision(20, 5);

        Assert.Equal(4, divisionResult);
    }

    [Fact]
    public void WhenDividingByZero_ThenReturnsZero()
    {
        var divisionResult = Program.safeDivision(20, 0);

        Assert.Equal(0, divisionResult);
    }
}