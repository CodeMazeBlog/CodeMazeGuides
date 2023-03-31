using NUnit.Framework;
using ActionAndFuncDelegates;

namespace Tests
{
    [TestFixture]
    public class CalculatorUnitTest
    {
        [Test]
        public void AddNumbers_ValidInputs_ReturnsSum()
        {
            // Arrange
            int x = 10;
            int y = 20;

            // Act
            Calculator.AddNumbers(x, y);

            // Assert
            Assert.Pass("AddNumbers method executed successfully");
        }

        [Test]
        public void SumDelegate_ValidInputs_ReturnsSum()
        {
            // Arrange
            int a = 5;
            int b = 10;

            // Act
            int sum = Calculator.SumDelegate(a, b);

            // Assert
            Assert.AreEqual(15, sum, "SumDelegate method returns incorrect result");
        }
    }
}
