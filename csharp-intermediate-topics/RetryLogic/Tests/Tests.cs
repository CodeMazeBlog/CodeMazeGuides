using Microsoft.VisualStudio.TestTools.UnitTesting;
using RetryLogic;
using RetryLogic.Exceptions;
using System;
using System.IO;
using System.Text;

namespace Tests
{
    [TestClass]
    public class Tests
    {
        private static readonly StringBuilder _consoleOutput = new();
        private const int _forbiddenNumber = 3;

        [TestInitialize]
        public void Init()
        {
            Console.SetOut(new StringWriter(_consoleOutput));
            _consoleOutput.Clear();
        }

        [TestMethod]
        [ExpectedException(typeof(RetryException), $"Error after 4 tries")]
        public void GivenTheFirstGameOfTest_WhenTheGeneratedNumberIsEqualToForbidden_ThenRetryTheActionAndThrowException()
        {
            Executor.Execute(() => FirstSiulationMethodOfTest(1,1,1), _forbiddenNumber);
        }

        [TestMethod]
        public void GivenTheFirstGameOfTest_WhenTheGeneratedNumberDifferFromForbidden_ThenExecuteTheAction()
        {
            Executor.Execute(() => FirstSiulationMethodOfTest(5, 10), 3);
        }

        [TestMethod]
        [ExpectedException(typeof(RetryException), $"Error after 4 tries")]
        public void GivenTheSecondGameOfTest_WhenTheGeneratedNumberIsEqualToForbidden_ThenRetryTheFunctionAndThrowException()
        {
            Executor.Execute(() => SecondSimulationMethodOfTest(3, 3, 3),3);
        }

        [TestMethod]
        public void GivenTheSeoncGameOfTest_WhenTheGeneratedNumberDifferFromForbidden_ThenExecuteTheFunctionAndReturnTheGeneratedNumber()
        {
            var result = Executor.Execute(() => SecondSimulationMethodOfTest(5, 10), 3);

            Assert.AreNotEqual(result, 0);
            Assert.AreEqual("Not Equal", _consoleOutput.ToString());
        }

        public static void FirstSiulationMethodOfTest(int min, int max, int forbiddenNumber = 0)
        {
            var number = new Random().Next(min, max);

            if (number == forbiddenNumber)
                throw new ArgumentException($"The generated number must be different from {forbiddenNumber}");

            Console.Write("Not Equal");
        }

        public static int SecondSimulationMethodOfTest(int min, int max, int forbiddenNumber = 0)
        {
            var number = new Random().Next(min, max);

            if (number == forbiddenNumber)
                throw new ArgumentException($"The generated number must be different from {forbiddenNumber}");

            Console.Write("Not Equal");

            return number;
        }
    }
}