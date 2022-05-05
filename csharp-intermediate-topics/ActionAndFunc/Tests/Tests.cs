namespace Tests;

using Xunit;
using System;
using ActionAndFuncExample;
public class Tests
{
    [Fact]
    public void GivenInitializedActionDelegate_InvocationListNotEmpty()
    {
        Action<string> action = Logger.LogToConsole;
        var invocationList = action.GetInvocationList();
        Assert.NotEmpty(invocationList);
    }
    [Fact]
    public void GivenInitializedFuncDelegate_InvocationListNotEmpty()
    {
        Func<int, int ,int> func = Calculator.Add;
        var invocationList = func.GetInvocationList();
        Assert.NotEmpty(invocationList);
    }

    [Fact]
    public void GivenInitializedActionDelegate_InvocationListContainsReferencedMethodName() 
    {
        Action<string> action = Logger.LogToConsole;
        var invocationList = action.GetInvocationList();
        Assert.Equal(nameof(Logger.LogToConsole), invocationList[0].Method.Name);
    }

    [Fact]
    public void GivenInitializedFuncDelegate_InvocationListContainsReferencedMethodName()
    {
        Func<int, int, int> func = Calculator.Add;
        var invocationList = func.GetInvocationList();
        Assert.Equal(nameof(Calculator.Add), invocationList[0].Method.Name);
    }

    [Theory]
    [InlineData(2,2,4)]
    [InlineData(4,15,19)]
    [InlineData(1982,-1979,3)]
    public void GivenTwoNumbers_FuncDelegateExecutesReferencedMethod(int num1, int num2, int expectedResult) 
    {
        Func<int, int, int> func = Calculator.Add;
        var result = func(num1, num2);
        Assert.Equal(expectedResult, result);
    }

}