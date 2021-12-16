using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests;

[TestClass]
public class Tests
{
    public static Func<int, int, int> Calculate { get; set; }
    public static Action<int> ChangeFlag { get; set; }
    public static int Flag = 1;

    public static int Add(int a, int b)
    {
        return a + b;
    }

    [TestMethod]
    public void whenMethodAssigned_FuncReturnsCorrectValue()
    {
        Calculate = Add;
        int result = Calculate(2, 4);
        Assert.AreEqual(6, result);
    }

    [TestMethod]
    public void whenLambdaExpressionAssigned_FuncReturnCorrectValue()
    {
        Calculate = (a, b) => a * b;
        int result = Calculate(3, 8);
        Assert.AreEqual(24, result);
    }

    [TestMethod]
    public void whenAnonymousMethodAssigned_FuncReturnsCorrectValue()
    {
        Calculate = delegate(int a, int b) { return a / b; };

        int result = Calculate(10, 5);
        Assert.AreEqual(2, result);
    }

    [TestMethod]
    public void whenLambdaExpressionAssigned_ActionWorksCorrectly()
    {
        ChangeFlag = n => Flag = n;
        Flag = 1;
        ChangeFlag(2);
        Assert.AreEqual(2, Flag);
    }

    [TestMethod]
    public void whenAnotherActionAppended_AddedActionWorks()
    {
        ChangeFlag = n => Flag = n;
        ChangeFlag += n => Flag = n * n;
        Flag = 1;
        ChangeFlag(2);
        Assert.AreNotEqual(2, Flag);
        Assert.AreEqual(4, Flag);
    }
}