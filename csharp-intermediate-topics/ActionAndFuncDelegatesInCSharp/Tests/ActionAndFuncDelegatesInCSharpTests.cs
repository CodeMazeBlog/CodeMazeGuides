using ActionAndFuncDelegatesInCsharp;

namespace Tests
{
    [TestClass]
    public class ActionAndFuncDelegatesInCSharpTests
    {
        [TestMethod]
        public void WhenSumTwoIntegers_ThenCorrectResult()
        {
            var firstNumber = 2;
            var secondNumber = 3;
            Assert.AreEqual(Program.Sum(firstNumber, secondNumber), 5);
        }

        [TestMethod]
        public void WhenAddActionWithNewInstance_DelegateInvocationListContainsOneElement()
        {
            Action<string> writeToConsoleActionNewInstance = new Action<string>(Program.WriteToConsole);
            Assert.AreEqual(writeToConsoleActionNewInstance.GetInvocationList().Length, 1);
        }

        [TestMethod]
        public void WhenAddActionByAssigningGroupMethod_DelegateInvocationListContainsOneElement()
        {
            Action<string> writeToConsoleActionNewInstance = Program.WriteToConsole;
            Assert.AreEqual(writeToConsoleActionNewInstance.GetInvocationList().Length, 1);
        }

        [TestMethod]
        public void WhenAddActionByUsingAnonymousMethod_DelegateInvocationListContainsOneElement()
        {
            Action<string> writeToConsoleActionNewInstance = delegate (string text)
            {
                Console.WriteLine(text);
            };
            Assert.AreEqual(writeToConsoleActionNewInstance.GetInvocationList().Length, 1);
        }

        [TestMethod]
        public void WhenAddActionByUsingLambdaExpression_DelegateInvocationListContainsOneElement()
        {
            Action<string> writeToConsoleActionNewInstance = text => Console.WriteLine(text);
            Assert.AreEqual(writeToConsoleActionNewInstance.GetInvocationList().Length, 1);
        }

        public void WhenAddFuncWithNewInstance_DelegateInvocationListContainsOneElement()
        {
            Func<int, int, int> sumTwoNumbersFuncNewInstance = new Func<int, int, int>(Program.Sum);
            Assert.AreEqual(sumTwoNumbersFuncNewInstance.GetInvocationList().Length, 1);
        }

        [TestMethod]
        public void WhenAddFuncByAssigningGroupMethod_DelegateInvocationListContainsOneElement()
        {
            Func<int, int, int> sumTwoNumbersFuncAssigning = Program.Sum;
            Assert.AreEqual(sumTwoNumbersFuncAssigning.GetInvocationList().Length, 1);
        }

        [TestMethod]
        public void WhenAddFuncByUsingAnonymousMethod_DelegateInvocationListContainsOneElement()
        {
            Func<int, int, int> sumTwoNumbersFuncAnonymous = delegate (int first, int second)
            {
                return Program.Sum(first, second);
            };
            Assert.AreEqual(sumTwoNumbersFuncAnonymous.GetInvocationList().Length, 1);
        }

        [TestMethod]
        public void WhenAddFuncByUsingLambdaExpression_DelegateInvocationListContainsOneElement()
        {
            Func<int, int, int> sumTwoNumbersFuncLambda = (first, second) => Program.Sum(first, second);
            Assert.AreEqual(sumTwoNumbersFuncLambda.GetInvocationList().Length, 1);
        }

        [TestMethod]
        public void WhenAddActionTwoMethods_DelegateInvocationListContainsTwoElements()
        {
            Action<string> writeToConsoleActionMulticasting = Program.WriteToConsole;
            writeToConsoleActionMulticasting += text => Console.WriteLine(text);
            Assert.AreEqual(writeToConsoleActionMulticasting.GetInvocationList().Length, 2);
        }
    }
}