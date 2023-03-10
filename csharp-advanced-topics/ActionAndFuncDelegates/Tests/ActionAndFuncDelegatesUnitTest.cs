using ActionAndFuncDelegates;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Tests
{
    [TestClass]
    public class ActionAndFuncDelegatesUnitTest
    {

        [TestMethod]
        public void WhenVoidActionDelegateCalled_DelegateExucutesTheReferenceMethod()
        {
            // Arrange
            string expectedOutput = "The input value is: 50";

            // Act
            string result = Program.ActionDelagate();

            // Assert
            Assert.AreEqual(expectedOutput, result);
        }

        [TestMethod]
        public void WhenNumberIsSent_DelegateExucutesTheReferenceMethod()
        {
            // Arrange
            int num = 20;
            string expectedOutput = $"The input value is: {num}";

            // Act
            string result = Program.ActionDelagateWithArguments(num);

            // Assert
            Assert.AreEqual(expectedOutput, result);
        }

        [TestMethod]
        public void WhenTwoNumbersAreSent_FunctionDelegateReturnSum()
        {
            // Arrange
            int expectedOutput = 50;

            // Act
            int reult = Program.FunctionDelagate(20, 30);

            //Assert
            Assert.AreEqual(expectedOutput, reult);

        }

        [TestMethod]
        public void WhenTwoStringsAreSent_FunctionDelegateReturnCombinedStrings()
        {
            // Arrange
            string firstName = "code";
            string lastName = "maze";
            string expectedOutput = $"Your Name is {firstName} {lastName}";

            // Act
            string reult = Program.FunctionDelagateWithArguments(firstName, lastName);

            //Assert
            Assert.AreEqual(expectedOutput, reult);
        }
    }
}