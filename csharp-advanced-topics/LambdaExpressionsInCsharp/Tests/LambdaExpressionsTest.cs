using LambdaExpressionsInCsharp;
using Xunit;

namespace Tests;

[Collection("Seq")]
public class LambdaExpressionsTest
{
    readonly StringWriter output;
    public LambdaExpressionsTest()
    {
        output = new StringWriter();
        Console.SetOut(output);
    }

    [Fact]
    public void WhenCallingExpressionLambdaWithNoReturnTypeAndNoParameters_ThenExpectedResult()
    {
        LambdaExpressions.ExpressionLambdaWithNoReturnTypeAndNoParameters();
        Assert.Contains("Hello!", output.ToString());
    }

    [Fact]
    public void WhenCallingExpressionLambdaWithNoReturnTypeAndWithParameters_ThenExpectedResult()
    {
        LambdaExpressions.ExpressionLambdaWithNoReturnTypeAndWithParameters();
        Assert.Contains("Hello CodeMaze", output.ToString());
    }

    [Fact]
    public void WhenCallingExpressionLambdaWithReturnTypeAndWithNoParameters_ThenExpectedResult()
    {
        LambdaExpressions.ExpressionLambdaWithReturnTypeAndWithNoParameters();
        Assert.Contains("Sum of two numbers is 2", output.ToString());
    }

    [Fact]
    public void WhenCallingExpressionLambdaWithReturnTypeAndWithParameters_ThenExpectedResult()
    {
        LambdaExpressions.ExpressionLambdaWithReturnTypeAndWithParameters();
        Assert.Contains("Square of 2 is: 4", output.ToString());
    }

    [Fact]
    public void WhenCallingStatementLambdaWithNoReturnTypeAndNoParameters_ThenExpectedResult()
    {
        LambdaExpressions.StatementLambdaWithNoReturnTypeAndNoParameters();
        Assert.Contains("Hello!", output.ToString());
    }

    [Fact]
    public void WhenCallingStatementLambdaWithNoReturnTypeAndWithParameters_ThenExpectedResult()
    {
        LambdaExpressions.StatementLambdaWithNoReturnTypeAndWithParameters();
        Assert.Contains("Hello CodeMaze", output.ToString());
    }

    [Fact]
    public void WhenCallingStatementLambdaWithReturnTypeAndWithNoParameters_ThenExpectedResult()
    {
        LambdaExpressions.StatementLambdaWithReturnTypeAndWithNoParameters();
        Assert.Contains("Sum of two numbers is 2", output.ToString());
    }

    [Fact]
    public void WhenCallingStatementLambdaWithReturnTypeAndWithParameters_ThenExpectedResult()
    {
        LambdaExpressions.StatementLambdaWithReturnTypeAndWithParameters();
        Assert.Contains("Square of 2 is: 4", output.ToString());
    }

    [Fact]
    public void WhenCallingLambdaWithExplicitReturnType_ThenExpectedResult()
    {
        LambdaExpressions.LambdaWithExplicitReturnType();
        Assert.Contains("Number is: 2", output.ToString());
    }

    [Fact]
    public void WhenCallingLambdaNaturalType_ThenExpectedResult()
    {
        LambdaExpressions.LambdaNaturalType();
        Assert.Contains("Hello!", output.ToString());
    }
}