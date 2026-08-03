using LambdaExpressionsInCsharp;
using Xunit;

namespace Tests;

[Collection("Seq")]
public class LambdaExpressionsInLinqTest
{
    readonly StringWriter output;
    public LambdaExpressionsInLinqTest()
    {
        output = new StringWriter();
        Console.SetOut(output);
    }

    [Fact]
    public void WhenCallingLinqOrderBy_ThenExpectedResult()
    {
        var lambdaExpressionsInLinq = new LambdaExpressionsInLinq();
        lambdaExpressionsInLinq.LinqOrderBy();
        Assert.Contains("apple,mango,orange,pineapple", output.ToString());
    }

    [Fact]
    public void WhenCallingLinqSelect_ThenExpectedResult()
    {
        var lambdaExpressionsInLinq = new LambdaExpressionsInLinq();
        lambdaExpressionsInLinq.LinqSelect();
        Assert.Contains("Fruits in upper case: APPLE,ORANGE,MANGO,PINEAPPLE", output.ToString());
    }

    [Fact]
    public void WhenCallingLinqFirst_ThenExpectedResult()
    {
        var lambdaExpressionsInLinq = new LambdaExpressionsInLinq();
        lambdaExpressionsInLinq.LinqFirst();
        Assert.Contains("Matched fruit is mango", output.ToString());
    }
}