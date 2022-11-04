namespace UsingStaticInCSharp.Tests;
public class UsingStaticUnitTest
{
    readonly StringWriter output;

    public UsingStaticUnitTest()
    {
        output = new StringWriter();
        Console.SetOut(output);
    }

    [Fact]
    public void GivenAStaticConstant_WhenCalledByUsingStaticFeature_ShouldReturnItsValue()
    {
        Constants.Caller.Invoke();
        Assert.Contains("The contants are Pending, InProgress, Completed", output.ToString());
    }

    [Fact]
    public void GivenANestedClassFromSampleClassOne_WhenCalledByUsingStaticFeature_ShouldReturnItsValue()
    {
        NestedTypeMembers.Caller.Invoke();
        Assert.Contains("NestedTypeMembers.ClassA.ClassB.MethodB() called", output.ToString());
    }

    [Fact]
    public void GivenAStaticMethodFromClassA_WhenCalledByUsingStaticFeature_ShouldReturnItsValue()
    {
        MethodsAndProperties.Caller.Invoke();
        Assert.Contains("MethodsAndProperties.ClassA.MethodA() called", output.ToString());
        Assert.Contains("MethodsAndProperties.ClassA.MethodB() called", output.ToString());
    }

    [Fact]
    public void GivenAAmbiguityMethodFromClassAAndClassB_WhenCalledByItsClassName_ShouldReturnItsValue()
    {
        Ambiguity.Caller.Invoke();
        Assert.Contains("UsingStaticInCSharp.Ambiguity.ClassA.Method() called", output.ToString());
        Assert.Contains("UsingStaticInCSharp.Ambiguity.ClassB.Method() called", output.ToString());
    }

    [Fact]
    public void GivenAEnum_WhenCalledByUsingStaticFeature_ShouldReturnItsValue()
    {
        Enums.Caller.Invoke();
        Assert.Contains("The enum items are Red, Green, Blue", output.ToString());
    }

    [Fact]
    public void GivenAnExtensionMethodInDifferentNamespace_WhenCalledByUsingStaticFeature_ShouldReturnItsValue()
    {
        ExtensionMethods.Caller.Invoke();
        Assert.Contains("The sum is 3", output.ToString());
    }
}