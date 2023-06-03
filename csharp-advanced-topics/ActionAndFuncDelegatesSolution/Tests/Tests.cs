using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using delegate_namespace;
using System;
using System.IO;


namespace Tests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void WhenGetCubeActionDelegateInvoked_ThenOutputResult()
        {
            int number = 7;
            string expected = "The result is 343";

            string actual = GetCubeResult(number);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void WhenGetSquareFuncDelegateInvoked_ThenReturnResult()
        {
            int number = 6;
            int expected = 36;

            int actual = GetSquareResult(number);

            Assert.AreEqual(expected, actual);
        }

        private string GetCubeResult(int number)
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                Delegates.GetCube(number);
                return sw.ToString().Trim();
            }
        }

        private int GetSquareResult(int number)
        {
            return Delegates.GetSquare(number);
        }
    }
}
