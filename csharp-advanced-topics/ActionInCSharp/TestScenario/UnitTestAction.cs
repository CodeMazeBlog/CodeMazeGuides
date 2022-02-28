using NUnit.Framework;
using System;

namespace TestScenario
{
    public class UnitTestAction
    {
        private static int resultNumber = 0;
        private static string resultMessage = "";
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void WhenPassingSingleValue_ThenLengthMatchConditionCheck()
        {
            Action<string> MessageView = ShowMessage;
            MessageView("Code Maze in Action");
                        
            Assert.AreNotEqual(resultMessage.Length, 1);
                        
            Assert.IsTrue(resultMessage.Length > 0);
        }

        [Test]
        public void WhenPassingMultipleValues_ThenNumberMatchConditionCheck()
        {
            Action<int, int> MultiplicationMethod = MultiplyNumbers;
            MultiplicationMethod(5, 3);
                        
            Assert.AreEqual(resultNumber, 15);
                        
            Assert.AreNotEqual(resultNumber, 10);
                        
            Assert.IsTrue(resultNumber > 0);
        }

        private static void MultiplyNumbers(int paramX, int paramY) { resultNumber = paramX * paramY; }
        private static void ShowMessage(string param) { resultMessage = param; }
    }
}