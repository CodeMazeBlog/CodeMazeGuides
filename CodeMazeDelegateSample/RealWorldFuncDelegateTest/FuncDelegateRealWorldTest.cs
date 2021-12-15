using Microsoft.VisualStudio.TestTools.UnitTesting;
using RealWorldFuncDelegate;
using System;
using System.Collections.Generic;
using System.IO;

namespace RealWorldFuncDelegateTest
{
    [TestClass]
    public class FuncDelegateRealWorldTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            using (var stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);

                TTMixDoubleParticipants ttMixDoubleParticipants = new TTMixDoubleParticipants();
                Func<List<string>, List<string>> toUpperFunctionPointer = Helpers.ConvertToUpperCaseList;
                Action<string> printerFunctionPointer = Helpers.Print;
                List<string> upperCaseList = toUpperFunctionPointer(ttMixDoubleParticipants.players);
                List<string> expected = new List<string>() { "BRUCE", "TINA", "TIM", "MINA" };
                CollectionAssert.AreEqual(expected, upperCaseList);
                upperCaseList.ForEach(printerFunctionPointer);
                Assert.IsTrue(stringWriter.ToString().Contains("BRUCE\r\nTINA\r\nTIM\r\nMINA\r\n"));
            }
        }
    }
}
