using ActionAndFuncDelegateAssessment;

namespace Tests;

public class ActionAndFuncDelegateAssessmentUnitTest
{
    [Fact]
    public void GivenNumbers_WhenPrinting_ThenAllNumbersArePrinted()
    {
        var numbers = new List<int> { 1, 2, 3, 4, 5 };
        const string expectedOutput = "1\n2\n3\n4\n5\n";

        using var consoleOutput = new StringWriter();
        Console.SetOut(consoleOutput);

        Examples.ActionDelegateExample(numbers);

        var actualOutput = consoleOutput.ToString();

        Assert.Equal(expectedOutput, actualOutput);
    }

    [Fact]
    public void WhenGivenNumbers_ThenReturnsSum()
    {
        IEnumerable<int> numbers = new List<int> { 0, 1, 2, 3, 4 };

        var result = Examples.FuncDelegateExample(numbers);

        Assert.Equal(10, result);
    }

    [Fact]
    public async Task GivenMultithreadExample_WhenCalculatingSum_ThenReturnsExpectedResult()
    {
        var result = await Examples.MultithreadExample();

        Assert.Equal(5000000050000000, result);
    }
}