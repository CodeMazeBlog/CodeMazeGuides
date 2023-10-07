using Microsoft.VisualStudio.TestTools.UnitTesting;
using ActionAndFuncDelegatesInCSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionAndFuncDelegatesInCSharp.Tests
{
    [TestClass()]
    public class ArithmeticOperationsUnitTests
    {
        [TestMethod()]
        public void GivenTwoNumbers_WhenSumIsInvoked_ThenSumIsReturned()
        {
            var operations = new ArithmeticOperations();

            Assert.AreEqual(5, operations.Sum(3, 2));
        }

        [TestMethod()]
        public void GivenTwoNumbers_WhenSubtractIsInvoked_ThenDifferenceIsReturned()
        {
            var operations = new ArithmeticOperations();

            Assert.AreEqual(1, operations.Subtract(3, 2));
        }

        [TestMethod()]
        public void GivenTwoNumbers_WhenMultiplyIsInvoked_ThenProductIsReturned()
        {
            var operations = new ArithmeticOperations();

            Assert.AreEqual(6, operations.Multiply(3, 2));
        }

        [TestMethod()]
        public void GivenTwoNumbers_WhenMDivideIsInvoked_ThenQuotientIsReturned()
        {
            var operations = new ArithmeticOperations();

            Assert.AreEqual(1.5, operations.Divide(3, 2));
        }
    }
}