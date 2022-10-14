using ActionAndFuncDelegatesInCSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests
{
    [TestClass]
    public class Tests
    {
        private double GetRoot(double value)
        {
            return Math.Sqrt(value);
        }

        private double GetSquare(double value)
        {
            return Math.Pow(value, 2);
        }

        [TestMethod]
        public void WhenValue100_ThenSquare10000()
        {
            var value = 100;
            var result = Methods.GetProcessResult(value, new Func<double, double>(GetSquare));
            Assert.AreEqual(10000, result);
        }

        [TestMethod]
        public void WhenValue100_ThenRoot10()
        {
            var value = 100;
            var result = Methods.GetProcessResult(value, new Func<double, double>(GetRoot));
            Assert.AreEqual(10, result);
        }

    }
}