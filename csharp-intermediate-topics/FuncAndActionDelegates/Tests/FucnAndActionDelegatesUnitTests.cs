using FuncAndActionDelegates.DTO;
using FuncAndActionDelegates.Global;
namespace Tests
{
    public class Tests
    {
        [Test]
        public void GivenCustomerWithLowLoyaltyPoints_WhenCalculatingDiscount_ThenReturnZeroDiscount()
        {
            // Arrange (Given)
            Order order = new Order { Customer = new Customer { Name = "Customer2", LoyaltyPoints = 50 }, TotalAmount = 1000 };

            // Act (When)
            double discount = DiscountHelper.CalculateDiscount(order);

            // Assert (Then)
            Assert.AreEqual(0, discount); // No discount expected for this scenario
        }

        [Test]
        public void GivenCustomerWithHighLoyaltyPoints_WhenCalculatingDiscount_ThenReturnDiscount()
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