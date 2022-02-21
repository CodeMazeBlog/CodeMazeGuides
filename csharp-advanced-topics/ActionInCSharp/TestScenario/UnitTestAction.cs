using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestScenario
{
    [TestClass]
    public class UnitTestAction
    {
        private static int resultNumber = 0;
        private static string resultMessage = "";
        [TestMethod]
        public void When_PassingSingleValue()
        {
            Action<string> MessageView = ShowMessage;
            MessageView("Code Maze in Action");

            //Length match
            Assert.AreNotEqual(resultMessage.Length, 1);

            //Condition check
            Assert.IsTrue(resultMessage.Length > 0);
        }

        [TestMethod]
        public void When_PassingMultipleValues()
        {
            Action<int, int> MultiplicationMethod = MultiplyNumbers;
            MultiplicationMethod(5, 3);

            //Number match
            Assert.AreEqual(resultNumber, 15);

            //Number mis-match
            Assert.AreNotEqual(resultNumber, 10);

            //Condition check
            Assert.IsTrue(resultNumber > 0);
        }

        private static void MultiplyNumbers(int paramX, int paramY) { resultNumber = paramX * paramY; }
        private static void ShowMessage(string param) { resultMessage = param; }
    }
}
