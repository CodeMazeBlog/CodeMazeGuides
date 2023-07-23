using Moq;

namespace UsingStaticInCSharp.Tests;
public class UsingStaticUnitTest
{
    [Fact]
    public void GivenAStaticConstant_WhenCalledByUsingStaticFeature_ShouldBeInvoked()
    {
        var mock = new Mock<Constants.Caller>();
        mock.Object.Invoke();

        mock.Verify(x => x.Invoke());
    }

    [Fact]
    public void GivenANestedClassFromSampleClassOne_WhenCalledByUsingStaticFeature_ShouldBeInvoked()
    {
        var mock = new Mock<NestedTypeMembers.Caller>();
        mock.Object.Invoke();

        mock.Verify(x => x.Invoke());
    }

    [Fact]
    public void GivenAStaticMethodFromClassA_WhenCalledByUsingStaticFeature_ShouldBeInvoked()
    {
        var mock = new Mock<MethodsAndProperties.Caller>();
        mock.Object.Invoke();

        mock.Verify(x => x.Invoke());
    }

    [Fact]
    public void GivenAAmbiguityMethodFromClassAAndClassB_WhenCalledByItsClassName_ShouldBeInvoked()
    {
        var mock = new Mock<Ambiguity.Caller>();
        mock.Object.Invoke();

        mock.Verify(x => x.Invoke());
    }

    [Fact]
    public void GivenAEnum_WhenCalledByUsingStaticFeature_ShouldBeInvoked()
    {
        var mock = new Mock<Enums.Caller>();
        mock.Object.Invoke();

        mock.Verify(x => x.Invoke());
    }

    [Fact]
    public void GivenAnExtensionMethodInDifferentNamespace_WhenCalledByUsingStaticFeature_ShouldBeInvoked()
    {
        var mock = new Mock<ExtensionMethods.Caller>();
        mock.Object.Invoke();

        mock.Verify(x => x.Invoke());
    }
}