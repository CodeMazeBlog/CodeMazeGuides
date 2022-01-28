using DelegatesExample;
using System.Collections.Generic;
using Xunit;

namespace Delegates.Tests
{
    public class DemeMethodsUnitTests
    {      
        [Fact]
        public void GivenListOfProducts_WhenCalculateTotalPrice_ThenReturnTotal()
        {
            //Arrange
            var delegateExample = new DelegateExample();
            List<Product> products = new List<Product>() {
                new Product()
                {
                    Label = "HP laptop",
                    Price = 2000
                },
                new Product()
                {
                    Label = "Logitek keyboard",
                    Price = 200
                }
            };

            //Act
            var total = delegateExample.CalculcateTotal(products);

            //Assert
            Assert.Equal(2200, total);
        }
    }
}