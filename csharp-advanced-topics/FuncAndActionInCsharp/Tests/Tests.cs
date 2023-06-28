using Microsoft.VisualStudio.TestPlatform.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests
{
   
    [TestClass]
    public class Tests
    {
        
        static Func<string> myFuncDelegate = PrintMsg;
        static Action<string> greetAction = Greet;
        private static string PrintName()
        {
            return "Hi! My name is John!";
        }
        private static string PrintMsg()
        {
            return "Hi! We are in PrintMsg Method";
        }
        private static void Greet(string name)
        {
            Console.WriteLine($"Hello, {name}!");
        }

        [TestMethod]
        public void WhenPrintMsgCalled_FuncReturnsTheString()
        {
            var testFunc = myFuncDelegate();
            Assert.AreEqual("Hi! We are in PrintMsg Method", testFunc);
        }

        [TestMethod]
        public void WhenActionDelegate_InvocationListNotEmpty()
        {
            var invocationList = greetAction.GetInvocationList();
            Assert.AreEqual(invocationList.Length, 1);
        }

        [TestMethod]
        public void WhenMyFuncDelegate_DelegateInvocationListNotEmpty()
        {
            Func<string> executeReverseWriteAction = PrintMsg;
            var invocationList = executeReverseWriteAction.GetInvocationList();
            Assert.AreEqual(invocationList.Length, 1);
        }
        [TestMethod]
        public void GivenMulticastFuncDelegate_whenTwoReferencedMethodAndPlusEquals_FuncDelegateInvocationListContainsTwoMethods()
        {
            var Funcdelegate1 = PrintMsg;
            var Funcdelegate2 = PrintName;
            var multicastDelegate = Funcdelegate1;
            multicastDelegate += Funcdelegate2;

            var invocationList = multicastDelegate.GetInvocationList();

            Assert.AreEqual(invocationList.Length, 2);
            Assert.AreEqual(invocationList[0].Method.Name, "PrintMsg");
            Assert.AreEqual(invocationList[1].Method.Name, "PrintName");
        }


    }
}