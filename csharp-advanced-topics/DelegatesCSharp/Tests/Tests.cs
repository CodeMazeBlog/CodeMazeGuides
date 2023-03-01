using ActionAndFuncDelegatesInCSharp;

namespace Tests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void WhenInvoked_ThenOutputHelloWorld()
        {
            // Arrange
            string expectedOutput = "Hello, world!\r\n";

            // Act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                Program.PrintMessage();
                string actualOutput = sw.ToString();

                // Assert
                Assert.AreEqual(expectedOutput, actualOutput);
            }
        }

        [TestMethod]
        public void WhenTwoNumbersAreProvided_ThenReturnsSumOfNumbers()
        {
            // Arrange
            int a = 10;
            int b = 20;
            int expectedSum = 30;

            // Act
            int actualSum = Program.AddNumbers(a, b);

            // Assert
            Assert.AreEqual(expectedSum, actualSum);
        }
    }
}