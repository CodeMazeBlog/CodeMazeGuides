using LambdaExpressionsInCsharp;
using Xunit;

namespace Tests;

[Collection("Seq")]
public class LambdaExpressionsInEventsTest
{
    readonly StringWriter output;
    public LambdaExpressionsInEventsTest()
    {
        output = new StringWriter();
        Console.SetOut(output);
    }

    [Fact]
    public void WhenCallingInvokeEvent_ThenExpectedResult()
    {
        var lambdaExpressionsInEvents = new LambdaExpressionsInEvents();
        lambdaExpressionsInEvents.InvokeEvent();
        Assert.Contains("Event raised!", output.ToString());
    }
}