namespace Tests;

using System;
using ActionAndFuncExample;
using Xunit;

public class Tests
{
    [Fact]
    public void GivenActionDelegate_WhenInitialized_ThenInvocationListIsNotEmpty()
    {
        Action<string> action = Logger.LogToConsole;
        var invocationList = action.GetInvocationList();
        Assert.NotEmpty(invocationList);
    }

    [Fact]
    public void GivenFuncDelegate_WhenIntialized_ThenInvocationListIsNotEmpty()
    {
        Func<int, int, int> func = Calculator.Add;
        var invocationList = func.GetInvocationList();
        Assert.NotEmpty(invocationList);
    }

    [Fact]
    public void GivenActionDelegate_WhenInitialized_ThenInvocationListContainsReferencedMethodName()
    {
        Action<string> action = Logger.LogToConsole;
        var invocationList = action.GetInvocationList();
        Assert.Equal(nameof(Logger.LogToConsole), invocationList[0].Method.Name);
    }

    [Fact]
    public void GivenFuncDelegate_WhenInitialized_ThenInvocationListContainsReferencedMethodName()
    {
        Func<int, int, int> func = Calculator.Add;
        var invocationList = func.GetInvocationList();
        Assert.Equal(nameof(Calculator.Add), invocationList[0].Method.Name);
    }

    [Theory]
    [InlineData(2, 2)]
    [InlineData(4, 15)]
    [InlineData(1982, -1979)]
    public void GivenFuncDelegate_WhenInvoked_ThenExecutesReferencedMethod(int num1, int num2)
    {
        Func<int, int, int> func = Calculator.Add;
        var expectedResult = Calculator.Add(num1,num2);
        var result = func(num1, num2);
        Assert.Equal(expectedResult, result);
    }

}
