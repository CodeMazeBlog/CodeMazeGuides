using ActionAndFuncDelegatesInCSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    public class FuncDelegateUnitTests
    {
        [TestMethod]
        public void WhenFuncDelegateIsAssignedSum_ThenSumIsReturned()
        {
            var operations = new ArithmeticOperations();
            Func<double, double, double> operationDelegate = operations.Sum;

            Assert.AreEqual(5, operationDelegate(3, 2));
        }

        [TestMethod]
        public void WhenFuncDelegateIsAssignedSubtract_ThenDifferenceIsReturned()
        {
            var operations = new ArithmeticOperations();
            Func<double, double, double> operationDelegate = operations.Subtract;

            Assert.AreEqual(1, operationDelegate(3, 2));
        }

        [TestMethod]
        public void WhenFuncDelegateIsAssignedMultiply_ThenProductIsReturned()
        {
            var operations = new ArithmeticOperations();
            Func<double, double, double> operationDelegate = operations.Multiply;

            Assert.AreEqual(6, operationDelegate(3, 2));
        }

        [TestMethod]
        public void WhenFuncDelegateIsAssignedDivide_ThenQuotientIsReturned()
        {
            var operations = new ArithmeticOperations();
            Func<double, double, double> operationDelegate = operations.Divide;

            Assert.AreEqual(1.5, operationDelegate(3, 2));
        }
    }
}
