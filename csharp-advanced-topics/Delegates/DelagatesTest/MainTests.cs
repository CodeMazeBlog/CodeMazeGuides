using Delegates;

namespace DelagatesTest
{
    [TestClass]
    public class MainTests
    {
        [TestMethod]
        public void Main_LogsCalculations()
        {
            // Arrange
            var calculator = new Calculator();
            var logger = new Logger();
            using StringWriter sw = new();
            Console.SetOut(sw);

            calculator.CalculationPerformed += logger.LogCalculation;

            // Act
            Program.Main(new string[0]);

            // Assert
            string output = sw.ToString();
            Assert.IsTrue(output.Contains("8"));
            Assert.IsTrue(output.Contains("6"));
            Assert.IsTrue(output.Contains("15"));
            Assert.IsTrue(output.Contains("Hello, Alice!"));
            Assert.IsTrue(output.Contains("Hello, Bob!"));
        }
    }
}
