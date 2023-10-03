using ActionAndFuncDelegatesInCSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Tests
{
    [TestClass]
    public class ActionAndFuncDelegateUnitTests
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


        [TestMethod]
        public void WhenFuncDelegateIsAssignedLambda_ThenLambdaIsExecuted()
        {
            Func<double, double, double> op = (a, b) => Math.Pow(a, b);
            Assert.AreEqual(9, op(3, 2));
        }

        [TestMethod]
        public void WhenActionDelegateIsAssignedLambda_ThenLambdaIsExecuted()
        {
            string message = "";
            Action<string> op = (input) => message = input;
            op("test");
            Assert.AreEqual("test", message);
        }

        [TestMethod]
        public void WhenFuncDelegateIsPassedToAFunction_ThenTheFunctionUsesIt()
        {
            var operations = new ArithmeticOperations();
            double result = operations.ExecArithmeticOperation(operations.Multiply, 2, 3);

            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void WhenFuncDelegatesArePutInAList_ThenTheyAreUsedInALoop()
        {
            var operations = new ArithmeticOperations();

            List<Func<double, double, double>> functions = new()
            {
                operations.Sum,
                operations.Multiply,
                (a, b) => Math.Pow(a, b),
            };

            double a = 3;
            double b = 2;
            double res = 0;
            foreach (var f in functions)
            {
                res += f(a, b);
            }
            Assert.AreEqual(20, res);
        }
    }
}
