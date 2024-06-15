namespace Tests;

using LocalFunctionsVsLambdaExpressionsInCSharp;

[TestClass]
public class RecursivityTests
{
    [TestMethod]
    public void WhenCalculatingFactorialAsLocalFunction_ResultIsCorrect()
    {
        var factorial = Recursivity.FactorialAsLocalFunction(5);
        Assert.AreEqual(120, factorial);
    }

    [TestMethod]
    public void WhenCalculatingFactorialAsLambdaExpression_ResultIsCorrect()
    {
        var factorial = Recursivity.FactorialAsLambdaExpression(5);
        Assert.AreEqual(120, factorial);
    }
}