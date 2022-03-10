using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ActionAndFunc.Tests;

[TestClass]
public class DelegateUnitTest
{
    [TestMethod]
    public void GivenListOfOperands_WhenOperationIsAddWithDelegate_ThenGetSumOfList()
    {
        var calculator = new Calculator();
        var operands = new int[] { 1, 2, 3, 4 };
        Calculator.Operation<int, int, int> adder = (op1, op2) => op1 + op2;

        var result = calculator.ExecuteOperationOverListWithDelegate(adder, operands);

        Assert.AreEqual(10, result);
    }

    [TestMethod]
    public void GivenListOfOperands_WhenOperationIsAddWithFunc_ThenGetSumOfList()
    {
        var calculator = new Calculator();
        var operands = new int[] { 1, 2, 3, 4 };
        var adder = int (int op1, int op2) => op1 + op2;

        var result = calculator.ExecuteOperationOverListWithFunc(adder, operands);

        Assert.AreEqual(10, result);
        Assert.IsInstanceOfType(adder, typeof(Func<int, int, int>));
    }

    [TestMethod]
    public void GivenListOfTransformation_WhenAppliedToString_ThenGetTransformedString()
    {
        var s = "TesT";
        var transformations = (Action) Delegate.Combine(
            (Action) (() => { s = s.ToLower(); }), 
            (Action) (() => { s = s.Replace('e', 'o'); })
        );

        transformations();

        Assert.IsInstanceOfType(transformations, typeof(MulticastDelegate));
        Assert.AreEqual("tost", s);
    }
}