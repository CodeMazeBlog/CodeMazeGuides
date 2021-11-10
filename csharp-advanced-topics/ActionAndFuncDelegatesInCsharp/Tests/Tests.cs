using Microsoft.VisualStudio.TestTools.UnitTesting;
using ActionAndFuncDelegatesInCsharp;
using System;

namespace Tests
{
    [TestClass]
    public class Tests
    {
        public static string PrintResult(CalculationDelegate operation, double x, double y) => string.Format("{0}({1}, {2}) = {3}", operation.Method.Name, x, y, operation(x, y));

        [TestMethod]
        public void sumOperationTest()
        {
            CalculationDelegate delegate1 = Program.Sum;
            var result = delegate1(3, 4);
            Assert.AreEqual("Sum(3, 4) = 7", PrintResult(delegate1, 3, 4));
        }

        [TestMethod]
        public void multiplyOperationTest()
        {
            CalculationDelegate delegate1 = Program.Multiply;
            var result = delegate1(3, 4);
            Assert.AreEqual("Multiply(3, 4) = 12", PrintResult(delegate1, 3, 4));
        }

        [TestMethod]
        public void dateTimeYesterdayTest()
        {
            Func<double, DateTime> dateTimeBackwards = (daysBackwards) => DateTime.Now.AddDays(-daysBackwards);
            Assert.AreEqual(DateTime.Now.AddDays(-5).ToShortDateString(), dateTimeBackwards(5).ToShortDateString());
        }

        [TestMethod]
        public void PrintResultAcceptsCalculationDelegate()
        {
            CalculationDelegate del = (x, y) => x - y;
            Program.PrintResult(del, 6, 7);
        }

        [TestMethod]
        public void HelloWorldTest()
        {
            Program.HelloWorld();
        }
    }
}
