using Microsoft.VisualStudio.TestTools.UnitTesting;
using ActionAndFuncDelegatesInCSharp;
using System;

namespace Tests
{
    [TestClass]
    public class ActionAndFuncDelegatesUnitTest
    {
        [TestMethod]
        public void WhenPrintingTextWithAction_ThenPrintText()
        {
            ActionFuncDelegate actionFuncDelegate = new ActionFuncDelegate();
            actionFuncDelegate.PrintText("Hello", "World");
            Assert.AreEqual("Hello World", actionFuncDelegate.Result);
        }

        [TestMethod]
        public void WhenPrintingTextGreetingWithAction_ThenPrintTextGreeting()
        {
            ActionFuncDelegate actionFuncDelegate = new ActionFuncDelegate();
            actionFuncDelegate.PrintTextGreeting("Hello", "World");
            Assert.AreEqual("Hello World, welcome to the show!", actionFuncDelegate.Result);
        }

        [TestMethod]
        public void WhenPrintingDateTimeWithAction_ThenPrintDateTime()
        {
            ActionFuncDelegate actionFuncDelegate = new ActionFuncDelegate();
            actionFuncDelegate.PrintDateTime();
            Assert.AreEqual(DateTime.Now.ToString(), actionFuncDelegate.Result);
        }

        [TestMethod]
        public void WhenGettingGreetingWithFunc_ThenGetGreeting()
        {
            ActionFuncDelegate actionFuncDelegate = new ActionFuncDelegate();
            var result = actionFuncDelegate.GetGreeting();
            Assert.AreEqual("Hello World", result);
        }

        [TestMethod]
        public void WhenMultiplyingIntegersWithFunc_ThenMultiplyIntegers()
        {
            ActionFuncDelegate actionFuncDelegate = new ActionFuncDelegate();
            var result = actionFuncDelegate.MultiplyIntegers(10, 10);
            Assert.AreEqual(100, result);
        }
    }
}
