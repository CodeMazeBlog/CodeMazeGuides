using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;

namespace Tests
{
    [TestClass]
    public class DelegatesTests
    {
        string fakeConsole;
        Dictionary<DayOfWeek, Action> isItFridayYetDictionaryOfActions;
        public DelegatesTests()
        {
            isItFridayYetDictionaryOfActions = new Dictionary<DayOfWeek, Action>
            {
                {DayOfWeek.Friday, () => fakeConsole = "Yeeeeeeey it's Friday !!!"}
            };
        }

        void PrintHelloParam1(string param1)
        {
            fakeConsole = $"Hello {param1}";
        }
        string ReturnHelloParam1(string param1)
        {
            return $"Hello {param1}";
        }

        [TestMethod]
        public void WhenParameterIsSent_PrintsHelloParameter()
        {
            PrintHelloParam1("World");
            Assert.AreEqual("Hello World", fakeConsole);
        }

        [TestMethod]
        public void WhenParameterIsSent_ReturnsHelloParameter()
        {
            var result = ReturnHelloParam1("World");
            Assert.AreEqual("Hello World", result);
        }

        [TestMethod]
        public void GivenActionDelegate_WhenMethodPrintHelloParam1IsReferenced_MethodIsExecutedAndPrintsHelloParameter()
        {
            Action<string> myDelegateAction = PrintHelloParam1;
            
            myDelegateAction("world with action-delegate");
            Assert.AreEqual("Hello world with action-delegate", fakeConsole);
        }

        [TestMethod]
        public void GivenFuncDelegate_WhenMethodReturnHelloParam1IsReferenced_MethodIsExecutedAndReturnsHelloParameter()
        {
            Func<string, string> myDelegateFunc = ReturnHelloParam1;
            Assert.AreEqual("Hello world with func-delegate", myDelegateFunc("world with func-delegate"));
        }

        [TestMethod]
        public void GivenActionDelegate_WhenFridayIsSentAsParameter_PrintsYeeeeyItsFriday()
        {
            isItFridayYetDictionaryOfActions[DayOfWeek.Friday].Invoke();
            Assert.AreEqual("Yeeeeeeey it's Friday !!!", fakeConsole);
        }
    }
}