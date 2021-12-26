using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass()]
    public class ActionFuncSampleTests
    {
        [TestMethod()]
        public void CallAnActionTest()
        {
            var actionCalled = false;
            ActionFuncSample.CallAnAction(() => actionCalled = true);
            Assert.IsTrue(actionCalled);
        }

        [TestMethod()]
        public void CallAFuncTest()
        {
            var funcCalled = false;
            ActionFuncSample.CallAFunc(() => funcCalled = true);
            Assert.IsTrue(funcCalled);
        }
    }
}