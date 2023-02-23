namespace Tests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void TestPrintMessage()
        {
            // Arrange
            string expectedOutput = "Hello, world!\r\n";

            // Act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                PrintMessage();
                string actualOutput = sw.ToString();

                // Assert
                Assert.AreEqual(expectedOutput, actualOutput);
            }
        }

        [TestMethod]
        public void TestAddNumbers()
        {
            // Arrange
            int a = 10;
            int b = 20;
            int expectedSum = 30;

            // Act
            int actualSum = AddNumbers(a, b);

            // Assert
            Assert.AreEqual(expectedSum, actualSum);
        }
    }
}