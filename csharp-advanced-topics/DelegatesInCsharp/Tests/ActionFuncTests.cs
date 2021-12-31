using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ActionFuncTests
    {
        [TestMethod]
        public void WhenInvokeTheFunc_TheInternalImplementationExecute()
        {
            Func<int, double> func = i => Math.Pow(i, 2);

            var result = func(5);
            Assert.AreEqual(Math.Pow(5, 2), result);
        }

        [TestMethod]
        public void WhenInvokeTheAction_TheInternalImplementationExecute()
        {
            Action<int> action = i => { Assert.AreEqual(5, i); };
            action(5);
        }
    }
}