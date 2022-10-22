using ActionAndFuncDelegatesInCSharp;

namespace Tests;

public class PlotGraphUnitTest
{
    [Fact]
    public void GivenAHigherOrderFunctionThatAcceptsACustomDelegate_WhenPassingAnAnonymousMethod_ThenShouldCallThatMethod()
    {
        PlotGraphUsingCustomDelegate.GraphDelegate linearGraph = delegate(int x)
        {
            return 2 * x + 5;
        };

        var points = PlotGraphUsingCustomDelegate.PlotGraph(linearGraph);
        for (var i = 0; i < 10; i++)
        {
            Assert.Contains((i, linearGraph(i)), points);
        }
    }
    
    [Fact]
    public void GivenAHigherOrderFunctionThatAcceptsAFunc_WhenPassingALambdaExpression_ThenShouldCallThatMethod()
    {
var points = PlotGraphUsingFuncDelegate.PlotGraph(x => 2 * x + 5);
        for (var i = 0; i < 10; i++)
        {
            Assert.Contains((i, 2 * i + 5), points);
        }
    }
}
