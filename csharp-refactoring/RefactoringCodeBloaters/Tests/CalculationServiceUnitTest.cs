using Microsoft.VisualStudio.TestTools.UnitTesting;
using RefactoringCodeBloaters.LongMethod.Correct;

namespace Tests
{
    [TestClass]
    public class CalculationServiceUnitTest
    {
        private readonly CalculationService calculationService;
        public CalculationServiceUnitTest()
        {
            calculationService = new CalculationService();
        }

        [TestMethod]
        public void GivenPriceLessThan250_WhenCalculatingPriceAfterDiscount_ThenOriginalPriceIsReturned()
        {
            // Arrange
            int quantity = 2;
            int itemPrice = 100;
            double expected = 200;

            // Act
            var result = calculationService.CalculatePriceAfterDiscount(quantity, itemPrice);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GivenPriceGreaterThan250_WhenCalculatingPriceAfterDiscount_ThenPriceIsLowered()
        {
            // Arrange
            int quantity = 5;
            int itemPrice = 100;
            double expected = 475;

            // Act
            var result = calculationService.CalculatePriceAfterDiscount(quantity, itemPrice);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}