using LambdaExpressionsInCsharp;
using Xunit;

namespace Tests;

[Collection("Seq")]
public class AsyncLambdaExpressionsTest
{
    readonly StringWriter output;
    public AsyncLambdaExpressionsTest()
    {
        output = new StringWriter();
        Console.SetOut(output);
    }

    [Fact]
    public async Task WhenCallingAsyncExpressionLambda_ThenExpectedResult()
    {
        await AsyncLambdaExpressions.AsyncExpressionLambda();
        Assert.Contains("Completed async task", output.ToString());
    }

    [Fact]
    public async Task WhenCallingAsyncStatementLambda_ThenExpectedResult()
    {
        await AsyncLambdaExpressions.AsyncStatementLambda();
        Assert.Contains("Completed async task", output.ToString());
    }
}