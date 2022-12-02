using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ActionsAndFuncTest
{
    delegate string StringDelegate(string text);

    [TestClass]
    public class ActionsAndFuncsTest
    {
        static string ToUpperCase(string text) => text.ToUpper();
        static double SquareFunc(double number) => Math.Pow(number, 2);
        static void Square(double number)=> Console.WriteLine(Math.Pow(number, 2));
        [TestMethod]
        public void validateUpperCaseStringDelegateMethod()
        {
            var stringDelegate = new StringDelegate(ToUpperCase);
            var result= stringDelegate("test");
            Assert.AreEqual("TEST", result);
        }

        [TestMethod]
        public void validateSquareFuncTest()
        {
            Func<double, double> square = SquareFunc;
            var result = square(-5);
            Assert.AreEqual(25, result);
        }

        [TestMethod]
        public void validateSquareActionTest()
        {
            Action<double> squareAct = Square;
            var invocationList = squareAct.GetInvocationList();
            Assert.AreEqual(invocationList.Length, 1);
        }
    }
}