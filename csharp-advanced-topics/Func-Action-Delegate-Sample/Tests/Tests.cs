using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests
{
    [TestClass]
    public class Tests
    {
        string message=string.Empty;
        string Sum(int a, int b)
        {
            return (a + b).ToString();
        }

        [TestMethod]
        public void whenTwoNumbersArePassedForAddition_FuncDelegateReturnsSumAsString()
        {
            Func<int, int, string> funcForSum = Sum;
            var result = funcForSum(2, 4);
            Assert.AreEqual("6", result);
        }

        [TestMethod]
        public void whenTwoNumbersArePassedForAddition_FuncDelegateReturnsSum()
        {
            Func<int, int, string> funcForSum = Sum;
            var result = funcForSum(2, 4);
            Assert.AreNotEqual(6, result);
        }

        [TestMethod]
        public void whenMessagePassedForPrinting_ActionDelegatePrintIt()
        {
            Action<string> printer = m =>
            {
                message = m;
                Console.WriteLine(message);
            };
            printer("Yeah we did unit tests");
            Assert.AreEqual("Yeah we did unit tests", message);
        }

        [TestMethod]
        public void whenMessagePassedForPrinting_ActionDelegatePrintItWrong()
        {
            Action<string> printer = m =>
            {
                message = m;
                Console.WriteLine(message);
            };
            printer("Yeah we did unit tests");
            Assert.AreNotEqual("Yeah did unit tests", message);
        }
    }
}