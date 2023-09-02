using Moq;

namespace ActionAndFuncDelegates.Tests;

public class FuncDelegateUnitTest
{
    [Test]
    public void WhenMethodWithStringReturnValueAndNoParameterCalled_ThenPrintExpectedOutput()
    {
        var result = FuncDelegate.MethodWithStringReturnValueAndNoParameter();
        Assert.That(result, Is.EqualTo("Hello from code-maze"));
    }

    [Test]
    public void WhenMethodWith2IntsAndReturnAnIntCalled_ThenReturnSumOfInts()
    {
        var result = FuncDelegate.MethodWith2IntsAndReturnAnInt(22, 44);
        Assert.That(result, Is.EqualTo(66));
    }

    [Test]
    public void WhenMethodWithIntReturnAndBoolAndStringParameterCalled_ThenPrintExpectedOutput()
    {
        var mockFunc = new Mock<Func<bool, string, int>>();
        mockFunc.Setup(f => f(true, "test-name")).Returns(9);

        var result = mockFunc.Object(true, "test-name");
        Assert.That(result, Is.EqualTo(9));
    }

    [Test]
    public void WhenMethodWithIntReturnAndBoolAndStringParameterCalledWithFalse_ThenReturnExpectedOutput()
    {
        var result = FuncDelegate.MethodWithIntReturnAndBoolAndStringParameter(false, "test-name");
        Assert.That(result, Is.EqualTo(-1));
    }
}
