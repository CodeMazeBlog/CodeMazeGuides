using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;

namespace Tests
{
    [TestClass]
    public class DelegatesTests
    {
        StringWriter fakeConsole;
        Dictionary<DayOfWeek, Action> isItFridayYetDictionaryOfActions;
        public DelegatesTests()
        {
            fakeConsole = new StringWriter();
            Console.SetOut(fakeConsole);
            isItFridayYetDictionaryOfActions = new Dictionary<DayOfWeek, Action>
            {
                {DayOfWeek.Friday, () => Console.WriteLine("Yeeeeeeey it's Friday !!!")}
            };
        }

        void PrintHelloParam1(string param1)
        {
            Console.WriteLine($"Hello {param1}");
        }
        string ReturnHelloParam1(string param1)
        {
            return $"Hello {param1}";
        }

        [TestMethod]
        public void WhenParameterIsSent_PrintsHelloParameter()
        {
            PrintHelloParam1("World");
            Assert.AreEqual("Hello World\r\n", fakeConsole.ToString());
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
            Assert.AreEqual("Hello world with action-delegate\r\n", fakeConsole.ToString());
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
            Assert.AreEqual("Yeeeeeeey it's Friday !!!\r\n", fakeConsole.ToString());
        }
    }
}