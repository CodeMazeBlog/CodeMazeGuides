using ActionAndFuncDelegatesInCSharp;
using Moq;

namespace Tests;

public class ActionAndFuncDelegateTests
{

    [Fact]
    public void GivenLogStringAction_WhenCalled_ShouldLogAsExpected()
    {
        StringWriter sw = new();
        Console.SetOut(sw);

        ActionExamples.MethodReferenceExample("Sample value");

        var result = sw.ToString().Trim();
        var expectedResult = "Logging string: \"Sample value\"";
        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void GivenUppercaseStringAction_WhenCalled_ShouldReturnOriginalAndModifiedWord()
    {
        StringWriter sw = new();
        Console.SetOut(sw);

        ActionExamples.AnonymousMethodExample("Sample Word");

        var result = sw.ToString().Trim();
        var expectedResult = "Original word: Sample Word. Modified word: SAMPLE WORD.";
        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void GivenPrintSquareAction_WhenCalled_ShouldLogSquareOfNumber()
    {
        StringWriter sw = new();
        Console.SetOut(sw);

        ActionExamples.LambdaExpressionExample(9);

        var result = sw.ToString().Trim();
        var expectedResult = "Square of 9 is 81.";
        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public async Task GivenPowerFunc_WhenCalled_ShouldLogPowerOfNumbers()
    {
        StringWriter sw = new();
        Console.SetOut(sw);

        FunctionExamples.MethodReferenceExample(3.3, 3);

        string expectedOutput = $"Result of the operation is: {Math.Pow(3.3, 3):0.00}";
        string actualOutput = sw.ToString().Trim();

        Assert.Equal(expectedOutput, actualOutput);
    }

    [Fact]
    public async Task GivenPersonYearsFunc_WhenCalled_ShouldLogPowerOfNumbers()
    {
        StringWriter sw = new();
        Console.SetOut(sw);
        
        var timerProviderMock = new Mock<TimeProvider>();

        timerProviderMock
            .Setup(tp => tp.GetUtcNow())
            .Returns(new DateTime(2024, 1, 1));

        FunctionExamples.AnonymousMethodExample();

        var expectedOutput = "Danny is 21 years old.";
        var actualOutput = sw.ToString().Trim();

        Assert.Equal(expectedOutput, actualOutput);
    }

    [Fact]
    public async Task GivenGreeterFunc_WhenCalled_ShouldGreetPerson()
    {
        StringWriter sw = new();
        Console.SetOut(sw);

        var timerProviderMock = new Mock<TimeProvider>();

        timerProviderMock
            .Setup(tp => tp.GetUtcNow())
            .Returns(new DateTime(
                DateOnly.FromDateTime(DateTime.UtcNow), TimeOnly.MinValue.AddHours(6)));

        FunctionExamples.LambdaExpressionExample(timerProviderMock.Object);

        var expectedOutput = "Good morning, Jack!";
        var actualOutput = sw.ToString().Trim();

        Assert.Equal(expectedOutput, actualOutput);
    }
}