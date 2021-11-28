using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework.Internal;
using ActionAndFuncDelegates;
using System.Collections.Generic;
using System;
using System.Linq;

namespace ActionAndFuncDelegatesTest
{
    [TestClass]
    public class ActionFuncDelegates_Tests
    {
        [TestMethod]
        public void TestFunc()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Func<int, bool> isEvenFunc = x => x % 2 == 0;

            var evenNumbersByAnonymousMethod = numbers.Where(x => x % 2 == 0); //Use a lambda expression
            var evenNumbersByFunc = numbers.Where(isEvenFunc); //Use a Func
            var evenNumbersByExistingMethod = numbers.Where(ActionsAndFuncs.IsNumberEven); //Use a previously declared method

            Assert.AreEqual(5, evenNumbersByAnonymousMethod.Count());
            Assert.AreEqual(5, evenNumbersByFunc.Count());
            Assert.AreEqual(5, evenNumbersByExistingMethod.Count());

        }

        [TestMethod]
        public void TestAction()
        {
            var obj = new ActionsAndFuncs();
            obj.GreetUser(30, "John");
            Assert.AreEqual("John", obj.LastGreetedName);
        }

        [TestMethod]
        public void TestDelegate()
        {
            ActionsAndFuncs.MyMethod doubleDelegate = (x, y) => x * y; //Change the value of the doubleDelegate variable
            Assert.AreEqual(6, doubleDelegate(2, 3)); // myVal is 6
        }

    }
}
