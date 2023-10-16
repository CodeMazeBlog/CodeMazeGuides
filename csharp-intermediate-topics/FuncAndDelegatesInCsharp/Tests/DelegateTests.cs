using ActionAndFuncDelegatesInCSharp;

namespace Tests
{
    [TestClass]
    public class DelegateTests
    {
        [TestMethod]
        public void Given_ActionDelegate_When_GreetIsCalled_Then_DisplayGreetingMessage()
        {
            // Arrange
            string expectedOutput = "Hello, TestUser!"; // Replace with the expected output
            var consoleOutput = new System.IO.StringWriter();
            System.Console.SetOut(consoleOutput);

            // Act
            ActionDelegate.greet("TestUser"); // Call the method

            // Assert
            Assert.AreEqual(expectedOutput, consoleOutput.ToString().Trim());
        }

        [TestMethod]
        public void Given_FuncDelegate_When_AddIsCalled_Then_ReturnSum()
        {
            // Arrange
            int expected = 8; // Replace with the expected result

            // Act
            int actual = FuncDelegate.add(5, 3); // Call the method

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}