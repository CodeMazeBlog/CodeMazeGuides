using System;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class ActionFuncBaseTests
    {
        [TestMethod]
        public void WhenPrintListInvoked_ThenPrintOutAllElementsInList()
        {
            var numbers = new List<int> { 1, 2, 3, 4, 5 };
            string expectedPrintOut = "1\r\n2\r\n3\r\n4\r\n5\r\n";
            
            using (var consolePrintOut = new StringWriter())
            {
                Console.SetOut(consolePrintOut);
                ActionFuncBase.PrintList(numbers);
                string actualPrintOut = consolePrintOut.ToString();
                expectedPrintOut = expectedPrintOut.Replace("\r\n", "\n");
                actualPrintOut = actualPrintOut.Replace("\r\n", "\n");
                Assert.AreEqual(expectedPrintOut, actualPrintOut);
            }
        }

        [TestMethod]
        public void WhenTripleListInvoked_ThenReturnTripledElements()
        {
            var numbers = new List<int> { 1, 2, 3, 4, 5 };
            var expectedTripledResult = new List<int> { 3, 6, 9, 12, 15 };
            List<int> actualTripledResult = ActionFuncBase.TripleList(numbers);
            CollectionAssert.AreEqual(expectedTripledResult, actualTripledResult);
        }
    }
}
