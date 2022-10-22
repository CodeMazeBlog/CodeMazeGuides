using ActionAndFuncDelegatesInCSharp;

namespace Tests;

public class FuncUnitTest
{
    [Theory]
    [InlineData(4, 2)]
    [InlineData(9, 3)]
    [InlineData(25, 5)]
    public void GivenAFuncPointingToANamedMethod_WhenInvoking_ThenTheReferencedMethodCalled(double d, double expected)
    {
        var result = FuncDelegate.FindRootUsingFuncReferringANamedMethod(d);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(4, 2)]
    [InlineData(9, 3)]
    [InlineData(25, 5)]
    public void GivenAFuncPointingToAnAnonymousMethod_WhenInvoking_ThenTheReferencedMethodCalled(double d,
        double expected)
    {
        var result = FuncDelegate.FindRootUsingFuncReferringAnAnonymousMethod(d);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(4, 2)]
    [InlineData(9, 3)]
    [InlineData(25, 5)]
    public void GivenAFuncPointingToALambdaExpression_WhenInvoking_ThenTheReferencedMethodCalled(double d,
        double expected)
    {
        var result = FuncDelegate.FindRootUsingFuncReferringANamedMethod(d);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(1, 2, 3)]
    [InlineData(100, 1000, 1100)]
    [InlineData(25, 40, 65)]
    public void GivenAFunc_WhenCallingUsingInvoke_ThenTheReferencedMethodShouldBeCalled(int x, int y, int expected)
    {
        var result = FuncDelegate.FindSumByInvokingFuncUsingInvoke(x, y);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(new[] {90, 85, 70}, 90, 70)]
    [InlineData(new[] {95, 70, 65, 98}, 98, 65)]
    public void GivenAMulticastDelegate_WhenUsingGetInvocationList_ThenAbleToGetIndividualReturnValue(int[] marks, int max, int min)
    {
        var result = FuncDelegate.GettingReturnValueOfIndividualFromAMulticastDelegate(marks);
        Assert.Contains(max, result);
        Assert.Contains(min, result);
    }
}