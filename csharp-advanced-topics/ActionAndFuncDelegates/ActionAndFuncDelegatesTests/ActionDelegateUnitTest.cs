using Moq;

namespace ActionAndFuncDelegates.Tests;

[TestFixture]
public class ActionDelegateUnitTest
{
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
    public void WhenMethodWithStringParameterCalled_ThenPrintExpectedOutput()
    {
        var mock = new Mock<Action<string>>();
        mock.Setup(x => x("test-name")).Callback(ActionDelegate.MethodWithStringParameter).Verifiable(Times.Once);
    }

    [Test]
    public void WhenMethodWithStringAndBoolParameterCalled_ThenPrintExpectedOutput()
    {
        var mock = new Mock<Action<string, bool>>();
        mock.Setup(x => x("test-name", true)).Callback(ActionDelegate.MethodWithStringAndBoolParameter).Verifiable(Times.Once);
    }

    [Test]
    public void WhenMethodWithVoidReturnTypeAndNoParameterCalled_ThenPrintExpectedOutput()
    {
        var mock = new Mock<Action>();
        mock.Setup(x => x()).Callback(ActionDelegate.MethodWithVoidReturnTypeAndNoParameter).Verifiable(Times.Once);
    }
}
