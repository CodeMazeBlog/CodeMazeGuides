using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ActionAndFuncDelegatesUnitTest
    {
        public static void PrintStaticText() => Console.WriteLine("Action delegate");

        public static void Print(string message) => Console.WriteLine(message);

        public static int Addition(int num1, int num2) => num1 + num2;

        public static string PrintFullName(string firstName, string lastName) => string.Format("Your Name is {0} {1}", firstName, lastName);


        [TestMethod]
        public void WhenVoidActionDelegateCalled_DelegateExucutesTheReferenceMethod()
        {
            // Arrange
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            // Act
            Action printAction = ActionAndFuncDelegatesUnitTest.PrintStaticText;
            printAction();

            var output = consoleOutput.ToString();

            // Assert
            Assert.AreEqual("Action delegate\r\n", output);
        }

        [TestMethod]
        public void WhenStringIsSent_DelegateExucutesTheReferenceMethod()
        {
            // Arrange
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            // Act
            Action<string> printMessage = ActionAndFuncDelegatesUnitTest.Print;
            printMessage("Hello world");

            var output = consoleOutput.ToString();

            // Assert
            Assert.AreEqual("Hello world\r\n", output);
        }

        [TestMethod]
        public void WhenTwoNumbersAreSent_FunctionDelegateReturnSum()
        {
            // Arrange
            Func<int, int, int> addition = Addition;

            // Act
            int sum = addition(4, 5);

            //Assert
            Assert.AreEqual(9, sum);
        }

        [TestMethod]
        public void WhenTwoStringsAreSent_FunctionDelegateReturnCombinedStrings()
        {
            // Arrange
            Func<string, string, string> fullName = PrintFullName;

            // Act
            string name = fullName("code", "maze");

            //Assert
            Assert.AreEqual("Your Name is code maze", name);
        }
    }
}