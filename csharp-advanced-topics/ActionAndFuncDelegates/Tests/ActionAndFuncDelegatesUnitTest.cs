using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Tests
{
    [TestClass]
    public class ActionAndFuncDelegatesUnitTest
    {
        private static string output = string.Empty;

        public static void PrintStaticNumber() => output = "The input value is: 10";

        public static void PrintInputNumber(int number) => output = $"The input value is: {number}";
        public static int Addition(int num1, int num2) => num1 + num2;

        public static string PrintFullName(string firstName, string lastName) => $"Your Name is {firstName} {lastName}";


        [TestMethod]
        public void WhenVoidActionDelegateCalled_DelegateExucutesTheReferenceMethod()
        {
            // Arrange
            string expectedOutput = "The input value is: 10";
            Action printStaticNumber = PrintStaticNumber;

            // Act
            printStaticNumber();

            // Assert
            Assert.AreEqual(expectedOutput, output);
        }

        [TestMethod]
        public void WhenNumberIsSent_DelegateExucutesTheReferenceMethod()
        {
            // Arrange
            int input = 20;
            string expectedOutput = $"The input value is: {input}";
            Action<int> printInputNumber = PrintInputNumber;

            // Act
            printInputNumber(input);

            // Assert
            Assert.AreEqual(expectedOutput, output);
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