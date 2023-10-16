using ActionAndFuncDelegatesInCSharp;

namespace Tests
{
    [TestClass]
    public class DelegateTests
    {
        [TestMethod]
        public void GivenActionDelegate_WhenGreetIsCalled_ThenDisplayGreetingMessage()
        {
            // Arrange
            var expectedOutput = "Hello, TestUser!"; // Replace with the expected output
            var consoleOutput = new System.IO.StringWriter();
            System.Console.SetOut(consoleOutput);

            // Act
            ActionDelegate.greet("TestUser"); // Call the method

            // Assert
            Assert.AreEqual(expectedOutput, consoleOutput.ToString().Trim());
        }

        [TestMethod]
        public void GivenFuncDelegate_WhenAddIsCalled_ThenReturnSum()
        {
            // Arrange
            var expected = 8; // Replace with the expected result

            // Act
            var actual = FuncDelegate.add(5, 3); // Call the method

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}