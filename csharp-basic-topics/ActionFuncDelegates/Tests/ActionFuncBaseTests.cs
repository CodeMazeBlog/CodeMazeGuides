using System;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class ActionFuncBaseTests
    {
        [TestMethod]
        public void PrintList_PrintElementsInList()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
            string expectedPrintOut = "1\r\n2\r\n3\r\n4\r\n5\r\n";
            var consolePrintOut = new System.IO.StringWriter();
            Console.SetOut(consolePrintOut);

            ActionFuncBase.PrintList(numbers);
            string actualPrintOut = consolePrintOut.ToString();

            Assert.AreEqual(expectedPrintOut, actualPrintOut);
        }

        [TestMethod]
        public void TripleList_ReturnTripledElements()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
            List<int> expectedTripledResult = new List<int> { 3, 6, 9, 12, 15 };

            List<int> actualTripledResult = ActionFuncBase.TripleList(numbers);
            CollectionAssert.AreEqual(expectedTripledResult, actualTripledResult);
        }
    }
}
