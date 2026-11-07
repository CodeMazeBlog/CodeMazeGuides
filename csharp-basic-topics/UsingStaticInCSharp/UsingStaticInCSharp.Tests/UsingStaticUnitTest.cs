namespace UsingStaticInCSharp.Tests;

public class UsingStaticUnitTest
{
    private static string CaptureOutput(Action invoke)
    {
        var original = Console.Out;
        using var writer = new StringWriter();
        Console.SetOut(writer);
        try
        {
            invoke();
        }
        finally
        {
            Console.SetOut(original);
        }

        return writer.ToString();
    }

    [Fact]
    public void GivenAStaticMethodFromClassA_WhenCalledByUsingStaticFeature_ThenItRuns()
    {
        var output = CaptureOutput(() => new MethodsAndProperties.Caller().Invoke());

        Assert.Contains("MethodsAndProperties.ClassA.MethodA() called", output);
        Assert.Contains("MethodsAndProperties.ClassA.MethodB() called", output);
    }

    [Fact]
    public void GivenAnEnum_WhenItemsAreUsedByUsingStaticFeature_ThenTheyResolve()
    {
        var output = CaptureOutput(() => new Enums.Caller().Invoke());

        Assert.Contains("The enum items are User, Admin", output);
    }

    [Fact]
    public void GivenStaticConstants_WhenUsedByUsingStaticFeature_ThenTheyResolve()
    {
        var output = CaptureOutput(() => new Constants.Caller().Invoke());

        Assert.Contains("Pending, InProgress, Completed", output);
    }

    [Fact]
    public void GivenANestedClass_WhenCalledByUsingStaticFeature_ThenItRuns()
    {
        var output = CaptureOutput(() => new NestedTypeMembers.Caller().Invoke());

        Assert.Contains("NestedTypeMembers.ClassA.ClassB.MethodA() called", output);
        Assert.Contains("NestedTypeMembers.ClassA.ClassB.MethodB() called", output);
    }

    [Fact]
    public void GivenTheOuterClass_WhenImportedByUsingStatic_ThenTheNestedClassNeedsNoPrefix()
    {
        var output = CaptureOutput(() => new NestedTypeMembers.OuterTypeCaller().Invoke());

        Assert.Contains("NestedTypeMembers.ClassA.ClassB.MethodA() called", output);
        Assert.Contains("NestedTypeMembers.ClassA.ClassB.MethodB() called", output);
    }

    [Fact]
    public void GivenAnExtensionMethodInDifferentNamespace_WhenImportedByUsingStatic_ThenItIsFound()
    {
        var output = CaptureOutput(() => new ExtensionMethods.Caller().Invoke());

        Assert.Contains("The sum is 3", output);
    }

    [Fact]
    public void GivenADerivedClass_WhenItsOwnStaticMethodIsCalledByUsingStatic_ThenItRuns()
    {
        var output = CaptureOutput(() => new BaseClassMembers.Caller().Invoke());

        Assert.Contains("BaseClassMembers.ClassB.MethodB() called", output);
    }

    [Fact]
    public void GivenTwoClassesWithTheSameMethod_WhenCalledByClassName_ThenBothRun()
    {
        var output = CaptureOutput(() => new Ambiguity.Caller().Invoke());

        Assert.Contains("Ambiguity.ClassA.Method() called", output);
        Assert.Contains("Ambiguity.ClassB.Method() called", output);
    }

    [Fact]
    public void GivenAGlobalUsingStatic_WhenMathMembersAreCalledWithoutTypeName_ThenTheyResolve()
    {
        var output = CaptureOutput(() => new GlobalUsingStatic.Caller().Invoke());

        Assert.Contains("The hypotenuse is 5", output);
        Assert.Contains("The best score is 9", output);
    }

    [Fact]
    public void GivenAMemberWithTheSameName_WhenCalledUnqualified_ThenTheEnclosingTypeWins()
    {
        var output = CaptureOutput(() => new MemberPrecedence.Caller().Invoke());

        Assert.Contains("Describe() returned Caller.Describe()", output);
    }
}
