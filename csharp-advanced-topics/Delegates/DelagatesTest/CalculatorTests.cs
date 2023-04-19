using Delegates;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DelagatesTest
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void Add_WithValidInputs_RaisesCalculationPerformedEvent()
        {
            Calculator calculator = new();
            bool eventRaised = false;

            calculator.CalculationPerformed += (x, y) => eventRaised = true;

            int result = calculator.Add(3, 5);

            Assert.IsTrue(eventRaised);
        }

        [TestMethod]
        public void Subtract_WithValidInputs_RaisesCalculationPerformedEvent()
        {
            Calculator calculator = new();
            bool eventRaised = false;

            calculator.CalculationPerformed += (x, y) => eventRaised = true;

            int result = calculator.Subtract(5, 3);

            Assert.IsTrue(eventRaised);
        }

        [TestMethod]
        public void Multiply_ReturnsCorrectResult()
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            int result = calculator.Multiply(3, 4);

            // Assert
            Assert.AreEqual(12, result);
        }

        [TestMethod]
        public void Multiply_RaisesCalculationPerformedEvent()
        {
            // Arrange
            var calculator = new Calculator();
            int eventRaisedCount = 0;
            calculator.CalculationPerformed += (a, b) => eventRaisedCount++;

            // Act
            calculator.Multiply(3, 4);

            // Assert
            Assert.AreEqual(1, eventRaisedCount);
        }
    }
}

