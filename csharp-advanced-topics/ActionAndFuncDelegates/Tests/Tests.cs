using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests
{
    [TestClass]
    public class Tests
    {
        public delegate void OurFirstDelegate(int x);


        [TestMethod]
        public void WhenAParameterIsPassed_TheNumberIsDoubled()
        {
            var variable = 2;
            var result = DoubleTheVariable(variable);

            Assert.AreEqual(4, result);
        }
        [TestMethod]
        public void WhenAParameterIsPassed_TheDelegateExecutesTheReferencedMethod()
        {
            var firstDelegate = new OurFirstDelegate(PrintVariable);
            firstDelegate(4);
            var invocationList = firstDelegate.GetInvocationList();

            Assert.AreEqual(invocationList.Length, 1);
        }
        [TestMethod]
        public void WhenADelegateIsPassedToAFunction_TheMethodExecutesTheDelegate()
        {
            var firstDelegate = new OurFirstDelegate(PrintVariable);
            PassADelegeteToAFunction(firstDelegate);
            var invocationList = firstDelegate.GetInvocationList();

            Assert.AreEqual(invocationList.Length, 1);
        }
        [TestMethod]
        public void WhenAStringIsPassed_TheFuncDelegateExecutesTheReferencedMethod()
        {
            Func<string, string> HelloFuncDelegate = HelloFunction;
            var result = HelloFuncDelegate("Naruto");

            Assert.AreEqual(result, "Hello Naruto");
        }
        [TestMethod]
        public void WhenAStringIsPassed_TheActionDelegateExecutesTheReferencedMethod()
        {
            Action<string> GoodbyeActionDelegate = GoodbyeFunction;
            GoodbyeActionDelegate("Naruto");
            var invocationList = GoodbyeActionDelegate.GetInvocationList();


            Assert.AreEqual(invocationList.Length, 1);
        }

        public static int DoubleTheVariable(int parameter) { return parameter * 2; }

        public static void PrintVariable(int parameter) { Console.WriteLine(parameter); }

        public static void PassADelegeteToAFunction(OurFirstDelegate myDelegate) { myDelegate(100); }

        public static string HelloFunction(string name) { return "Hello " + name; }

        public static void GoodbyeFunction(string name) { Console.WriteLine("Goodbye " + name); }
    }
}
