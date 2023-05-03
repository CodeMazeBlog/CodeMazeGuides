using ActionandFunc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TernaryOperatorTests
{
    [TestClass]
    public class DelegatesUnitTest
    {
        
        [TestMethod]
        public void GivenAction_WhenInvoked_ThenActionExecuted()
        {
            bool actionExecuted = false;
            Action<int, string> action = (i, s) => actionExecuted = true;

            Delegates.DoAction(action);

            Assert.IsTrue(actionExecuted);
        }

        [TestMethod]
        public void GivenFunc_WhenInvoked_ThenFuncResultReturned()
        {
            Func<int, int, int> func = (x, y) => x + y;

            int result = Delegates.DoFunc(func);

            Assert.AreEqual(30, result);
        }
    }
}