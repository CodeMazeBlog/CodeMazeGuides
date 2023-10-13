using ActionAndFuncDelegatesInCSharp;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestActionDelegate()
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
        public void TestFuncDelegate()
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