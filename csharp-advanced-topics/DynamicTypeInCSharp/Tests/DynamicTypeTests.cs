using System.Reflection;
using System.Runtime.CompilerServices;
using DynamicTypeInCSharp;
using DynamicTypeInCSharp.Models;
using Microsoft.CSharp.RuntimeBinder;

namespace Tests;

public class DynamicTypeTests
{
    [Fact]
    public void GivenDynamicVariable_WhenNewValueIsAssigned_ThenRuntimeTypeFollowsTheValue()
    {
        dynamic testVariable = 5;
        Assert.Equal(typeof(int), testVariable.GetType());

        testVariable = "Hello World";
        Assert.Equal(typeof(string), testVariable.GetType());
    }

    [Fact]
    public void GivenStringInDynamicVariable_WhenIncremented_ThenRuntimeBinderExceptionIsThrown()
    {
        var ex = Assert.Throws<RuntimeBinderException>(Examples.ExampleDynamicWithException);

        Assert.Equal("Operator '++' cannot be applied to operand of type 'string'", ex.Message);
    }

    [Fact]
    public void GivenDynamicLogger_WhenMissingMethodIsCalled_ThenRuntimeBinderExceptionIsThrown()
    {
        var ex = Assert.Throws<RuntimeBinderException>(Examples.ExampleMissingMethodDefinitionException);

        Assert.Contains("does not contain a definition for 'LogTrace'", ex.Message);
    }

    [Fact]
    public void GivenEmployee_WhenWorkStatusIsReadByReflectionAndByDynamic_ThenBothReturnTheSameValue()
    {
        Assert.Equal(WorkStatus.NotWorking, Examples.ExampleReflection());
        Assert.Equal(WorkStatus.NotWorking, Examples.ExampleDynamic());
    }

    [Fact]
    public void GivenArrayAsICollection_WhenCountIsReadDynamically_ThenRuntimeBinderExceptionIsThrown()
    {
        var ex = Assert.Throws<RuntimeBinderException>(() => Examples.ExamplePrintCount(new int[20]));

        Assert.Equal("'System.Array' does not contain a definition for 'Count'", ex.Message);
    }

    [Fact]
    public void GivenDynamicParameter_WhenInspected_ThenItIsObjectWithDynamicAttribute()
    {
        var parameter = typeof(DynamicTypeTests)
            .GetMethod(nameof(TakesDynamic), BindingFlags.NonPublic | BindingFlags.Static)!
            .GetParameters()[0];

        Assert.Equal(typeof(object), parameter.ParameterType);
        Assert.NotNull(parameter.GetCustomAttribute<DynamicAttribute>());
    }

    private static void TakesDynamic(dynamic value) => _ = value;
}
