using Microsoft.VisualStudio.TestTools.UnitTesting;
using RealWorldActionDelegate;
using System;
using System.IO;

namespace RealWorldActionDelegateTest
{
    [TestClass]
    public class ActionDelegateRealWorldTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            using (var stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);

                TTMixDoubleParticipants ttMixDoubleParticipants = new TTMixDoubleParticipants();
                Action<string> toUpperFunctionPointer = Helpers.PrintUpperCase;
                ttMixDoubleParticipants.players.ForEach(toUpperFunctionPointer);

                Assert.IsTrue(stringWriter.ToString().Contains("BRUCE"));
                Assert.IsTrue(stringWriter.ToString().Contains("TINA"));
                Assert.IsTrue(stringWriter.ToString().Contains("TIM"));
                Assert.IsTrue(stringWriter.ToString().Contains("MINA"));
            }
        }
    }
}
