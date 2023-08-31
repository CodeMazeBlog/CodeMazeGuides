using ActionAndFuncDelegates;
using Moq;

namespace ActionAndFuncDelegates.Tests;

[TestFixture]
public class DelegatesUnitTest
{
    private string consoleOutput = string.Empty;

    [SetUp]
    public void RedirectConsoleOutput()
    {
        var writer = new StringWriter();
        Console.SetOut(writer);
    }

    [TearDown]
    public void RestoreConsoleOutput()
    {
        Console.SetOut(Console.Out);
    }

    [Test]
    public void WhenSimpleDelegateCalled_ThenCallMethodWithNoParameterAndReturType()
    {
        var mock = new Mock<SimpleDelegate>();
        mock.Setup(x=>x()).Verifiable(Times.Once);        
    }

    [Test]
    public void WhenSimpleDelegateWithStringReturnCalled_ThenPointToMethodWithStringReturnAndNoParameter()
    {
        var result = Delegates.MethodWithStringReturnTypeAndNoParameter();
        Assert.That(result, Is.EqualTo("Delegate with string return type"));
    }

    [Test]
    public void WhenDeletgateWithInputAndReturnCalled_ThenPointMethodWithInputParameterAndStringReturnType()
    {
        var result = Delegates.MethodWithStringReturnTypeAndStringParameter("code-maze");
        Assert.That(result, Is.EqualTo("Delegate with string return type and parameter code-maze"));
    }
}