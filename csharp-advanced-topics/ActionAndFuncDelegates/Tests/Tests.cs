using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ActionAndFuncDelegates;

namespace Tests
{
    [TestClass]
    public class Tests
    {

        [TestMethod]
        public void WhenAParameterIsPassed_TheNumberIsDoubled()
        {
            var variable = 2;
            var result = Program.DoubleTheVariable(variable);

            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void WhenAParameterIsPassed_TheDelegateExecutesTheReferencedMethod()
        {
            var firstDelegate = new Program.ourFirstDelegate(Program.PrintVariable);
            firstDelegate(4);

            var invocationList = firstDelegate.GetInvocationList();

            Assert.AreEqual(invocationList.Length, 1);
        }

        [TestMethod]
        public void WhenADelegateIsPassedToAFunction_TheMethodExecutesTheDelegate()
        {
            var firstDelegate = new Program.ourFirstDelegate(Program.PrintVariable);
            Program.PassADelegeteToAFunction(firstDelegate);

            var invocationList = firstDelegate.GetInvocationList();

            Assert.AreEqual(invocationList.Length, 1);
        }

        [TestMethod]
        public void WhenAStringIsPassed_TheFuncDelegateExecutesTheReferencedMethod()
        {
            Func<string, string> HelloFuncDelegate = Program.HelloFunction;
            var result = HelloFuncDelegate("Naruto");

            Assert.AreEqual(result, "Hello Naruto");
        }

        [TestMethod]
        public void WhenAStringIsPassed_TheActionDelegateExecutesTheReferencedMethod()
        {
            Action<string> GoodbyeActionDelegate = Program.GoodbyeFunction;
            GoodbyeActionDelegate("Naruto");

            var invocationList = GoodbyeActionDelegate.GetInvocationList();

            Assert.AreEqual(invocationList.Length, 1);
        }

    }
}
