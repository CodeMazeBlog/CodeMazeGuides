using CheckMethodIsCalledWithMoq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.Protected;

namespace Tests;

[TestClass]
public class MyClassUnitTest
{
    [TestMethod]
    public void GivenAPublicMethod_WhenCalledFromAnotherMethod_ThenVerify()
    {
        var myClass = new Mock<MyClass>(null!, null!, null!);

        myClass.Object.CallingPublicMethod();

        myClass.Verify(d => d.PublicMethod());
    }

    [TestMethod]
    public void GivenAPublicMethod_WhenCalledFromAnotherMethod_ThenUseVerifiable()
    {
        var myClass = new Mock<MyClass>(null!, null!, null!);
        myClass.Setup(c => c.PublicMethod()).Verifiable();

        myClass.Object.CallingPublicMethod();

        myClass.Verify();
    }

    [TestMethod]
    public void GivenAPublicMethod_WhenCalledFromAnotherMethod_ThenVerifyAll()
    {
        var myClass = new Mock<MyClass>(null!, null!, null!);
        myClass.Setup(c => c.PublicMethod()).Callback(() => {});

        myClass.Object.CallingPublicMethod();

        myClass.VerifyAll();
    }

    [TestMethod]
    public void GivenAPublicMethod_WhenCalledFromAnotherMethodManyTimes_ThenVerify()
    {
        var myClass = new Mock<MyClass>(null!, null!, null!);

        myClass.Object.CallingPublicMethod();
        myClass.Object.CallingPublicMethod();
        myClass.Object.CallingPublicMethod();

        myClass.Verify(c => c.PublicMethod(), Times.Exactly(3));
    }

    [TestMethod]
    public void GivenAPublicMethod_WhenNeverCalled_ThenVerifyWithTimesNever()
    {
        var myClass = new Mock<MyClass>(null!, null!, null!);

        myClass.Verify(c => c.PublicMethod(), Times.Never());
    }

    [TestMethod]
    public void GivenAProtectedMethod_WhenCalledFromAnotherMethod_ThenVerifyWithProtected()
    {
        var myClass = new Mock<MyClass>(null!, null!, null!);

        myClass.Object.CallingProtectedMethod();

        myClass.Protected().Verify("ProtectedMethod", Times.Once());
    }

    [TestMethod]
    public void GivenAnInternalMethod_WhenCalledFromAnotherMethod_ThenVerify()
    {
        var myClass = new Mock<MyClass>(null!, null!, null!);

        myClass.Object.CallingInternalMethod();

        myClass.Verify(d => d.InternalMethod());
    }

    [TestMethod]
    public void GivenAnExternalDep_WhenPublicMethodIsCalled_ThenVerify()
    {
        var depMock = new Mock<Dependency>();
        var myClass = new MyClass(depMock.Object, null!, null!);

        myClass.CallingDependencyPublicMethod();

        depMock.Verify(d => d.DepPublicMethod());
    }

    [TestMethod]
    public void GivenAnExternalDep_WhenInterfacePublicMethodIsCalled_ThenVerify()
    {
        var depMock = new Mock<IDependency>();
        var myClass = new MyClass(null!, depMock.Object, null!);

        myClass.CallingInterfaceDependencyPublicMethod();

        depMock.Verify(d => d.DepInterfacePublicMethod());
    }

    [TestMethod]
    public void GivenAnExternalDep_WhenAbstractPublicMethodIsCalled_ThenVerify()
    {
        var depMock = new Mock<AbstractDependency>();
        var myClass = new MyClass(null!, null!, depMock.Object);

        myClass.CallingAbstractDependencyPublicMethod();

        depMock.Verify(d => d.DepAbstractPublicMethod());
    }
}