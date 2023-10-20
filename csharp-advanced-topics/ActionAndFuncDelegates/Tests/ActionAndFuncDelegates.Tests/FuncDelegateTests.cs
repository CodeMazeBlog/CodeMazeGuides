
namespace ActionAndFuncDelegates.Tests;

[TestClass]
public class SquareDelegateTests
{
    [TestMethod]
    public void WhenSquareCalculatorCalled_ReturnSquareOfInputNumber()
    {
        var squareCalculatorFunc = new SquareCalculator().SquareCalculatorFunc;
        
        var result = squareCalculatorFunc(5);
        
        Assert.AreEqual(25, result);
    }

    [TestMethod]
    public void WhenSquareCalculatorCalled_DelegateInvocationListNotEmpty()
    {
        var squareCalculatorFunc = new SquareCalculator().SquareCalculatorFunc;
        
        var invocationList = squareCalculatorFunc.GetInvocationList();
        
        Assert.AreEqual(invocationList.Length, 1); 
    }
}
