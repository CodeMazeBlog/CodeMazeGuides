using ActionAndFuncDelegatesInCSharp;
using Moq;

namespace Tests;

public class ActionAndFuncDelegateTests
{

    [Fact]
    public void GivenLogStringAction_WhenCalled_ThenItShouldLogAsExpected()
    {
        var sw = new StringWriter();
        Console.SetOut(sw);

        ActionExamples.MethodReferenceExample("Sample value");

        var result = sw.ToString().Trim();
        const string expectedResult = "Logging string: \"Sample value\"";
        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void GivenUppercaseStringAction_WhenCalled_ThenItShouldReturnOriginalAndModifiedWord()
    {
        var sw = new StringWriter();
        Console.SetOut(sw);

        ActionExamples.AnonymousMethodExample("Sample Word");

        var result = sw.ToString().Trim();
        const string expectedResult = "Original word: Sample Word. Modified word: SAMPLE WORD.";
        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void GivenPrintSquareAction_WhenCalled_ThenItShouldLogSquareOfNumber()
    {
        var sw = new StringWriter();
        Console.SetOut(sw);

        ActionExamples.LambdaExpressionExample(9);

        var result = sw.ToString().Trim();
        const string expectedResult = "Square of 9 is 81.";
        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public async Task GivenPowerFunc_WhenCalled_ThenItShouldLogPowerOfNumbers()
    {
        var sw = new StringWriter();
        Console.SetOut(sw);

        FunctionExamples.MethodReferenceExample(3.3, 3);

        var expectedOutput = $"Result of the operation is: {Math.Pow(3.3, 3):0.00}";
        var actualOutput = sw.ToString().Trim();

        Assert.Equal(expectedOutput, actualOutput);
    }

    [Fact]
    public async Task GivenPersonYearsFunc_WhenCalled_ThenItShouldLogPowerOfNumbers()
    {
        var sw = new StringWriter();
        Console.SetOut(sw);
        
        var timerProviderMock = new Mock<TimeProvider>();

        timerProviderMock
            .Setup(tp => tp.GetUtcNow())
            .Returns(new DateTime(2024, 1, 1));

        FunctionExamples.AnonymousMethodExample();

        const string expectedOutput = "Danny is 21 years old.";
        var actualOutput = sw.ToString().Trim();

        Assert.Equal(expectedOutput, actualOutput);
    }

    [Fact]
    public async Task GivenGreeterFunc_WhenCalled_ThenItShouldGreetPerson()
    {
        var sw = new StringWriter();
        Console.SetOut(sw);

        var timerProviderMock = new Mock<TimeProvider>();

        timerProviderMock
            .Setup(tp => tp.GetUtcNow())
            .Returns(new DateTime(
                DateOnly.FromDateTime(DateTime.UtcNow), TimeOnly.MinValue.AddHours(6)));

        FunctionExamples.LambdaExpressionExample(timerProviderMock.Object);

        const string expectedOutput = "Good morning, Jack!";
        var actualOutput = sw.ToString().Trim();

        Assert.Equal(expectedOutput, actualOutput);
    }
}