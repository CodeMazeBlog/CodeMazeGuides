using Microsoft.VisualStudio.TestTools.UnitTesting;
using RefactoringCodeBloaters.LongMethod.Correct;

namespace Tests
{
    [TestClass]
    public class CalculationServiceTests
    {
        private readonly CalculationService calculationService;
        public CalculationServiceTests()
        {
            calculationService = new CalculationService();
        }

        [TestMethod]
        public void CalculateDiscount_LessThan250_ReturnsOriginalPrice()
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
        public void CalculateDiscount_GreaterThan250_ReturnsDiscountedPrice()
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