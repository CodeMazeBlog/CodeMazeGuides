using Microsoft.VisualStudio.TestTools.UnitTesting;
using Delegates;
using System;
using static Delegates.Delegates;

namespace ActionAndFuncDelegatesUnitTest
{
    [TestClass]
    public class ActionAndFunDelegatesUnitTest
    {
        [TestMethod]
        public void DelegatesTest()
        {
            RemoteControl rcDelegate1 = new RemoteControl(Delegates.Delegates.TurnOn);
            var result1 = rcDelegate1("Power On Button");
            RemoteControl rcDelegate2 = new RemoteControl(Delegates.Delegates.TurnOff);
            var result2 = rcDelegate2("Shut down Button");

            Assert.AreEqual("TV is Turned On", result1);
            Assert.AreEqual("TV is Turned Off", result2);
            
        }
    }
}