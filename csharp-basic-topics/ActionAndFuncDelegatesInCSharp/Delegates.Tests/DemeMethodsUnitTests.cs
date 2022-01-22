using System.Collections.Generic;
using Xunit;

namespace Delegates.Tests
{
    public class DemeMethodsUnitTests
    {
        [Fact]
        public void GivenOriginalPriceAndPercentDiscount_WhenCalulatingPrice_ThenReturnTotal()
        {
            //Arrange
            decimal originalPrice = 200;
            decimal percentDiscount = 50;
            var demoMethods = new DemoMethods();

            //Act
            var finalTotal = demoMethods.CalculateFinalTotal(originalPrice, percentDiscount);

            //Assert
            Assert.Equal(100, finalTotal);
        }

        [Fact]
        public void GivenAwesomeCalculatorAndListOfProducts_WhenCalculateClientOrders_ThenReturnTotal()
        {
            //Arrange
            var demoMethods = new DemoMethods();
            AwesomeCalculator awesomeCalculator = new AwesomeCalculator(demoMethods.CalculateFinalTotal);
            List<Product> products = new List<Product>() {
                new Product()
                {
                    Id = 1,
                    Label = "HP laptop",
                    Price = 2000
                },
                new Product()
                {
                    Id = 2,
                    Label = "Logitek keyboard",
                    Price = 200
                }
            };

            //Act
            var finalTotal = demoMethods.CalculateClientOrdersTotal(awesomeCalculator, products);

            //Assert
            Assert.Equal(1100, finalTotal);
        }
    }
}