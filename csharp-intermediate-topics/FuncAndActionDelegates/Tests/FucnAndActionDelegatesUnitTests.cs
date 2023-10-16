using FuncAndActionDelegates.DTO;
using NUnit.Framework;
using System;
using FuncAndActionDelegates.Global;

namespace Tests

{
    public class Tests
    {


        [Test]
        public void Given_CustomerWithLowLoyaltyPoints_When_CalculatingDiscount_Then_ReturnZeroDiscount()
        {
            // Arrange (Given)
            Order order = new Order { Customer = new Customer { Name = "Customer2", LoyaltyPoints = 50 }, TotalAmount = 1000 };

            // Act (When)
            double discount = DiscountHelper.CalculateDiscount(order);

            // Assert (Then)
            Assert.AreEqual(0, discount); // No discount expected for this scenario
        }

        [Test]
        public void Given_CustomerWithHighLoyaltyPoints_When_CalculatingDiscount_Then_ReturnDiscount()
        {
            // Arrange (Given)
            Order order = new Order { Customer = new Customer { Name = "Customer1", LoyaltyPoints = 150 }, TotalAmount = 1000 };

            // Act (When)
            double discount = DiscountHelper.CalculateDiscount(order);

            // Assert (Then)
            Assert.AreEqual(200, discount); // Expected discount for this scenario
        }



    }
}