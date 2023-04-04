using RefactoringObjectOrientationAbusers.TemporaryField.Correct;

namespace Tests
{
    [TestClass]
    public class BookstoreCustomersUnitTests
    {
        [TestMethod]
        public void WhenCustomerHasBoughtLessThanTenBooks_ThenReturnsLowerDiscountRate()
        {
            // Arrange
            var customer = new BookstoreCustomer
            {
                BoughtBooks = new List<string> { "Book 1", "Book 2" }
            };

            // Act
            var discountRate = customer.GetDiscountRate();

            // Assert
            Assert.AreEqual(0.05, discountRate);
        }

        [TestMethod]
        public void WhenCustomerHasNotBoughtAnyBooks_ThenReturnsLowerDiscountRate()
        {
            // Arrange
            var customer = new BookstoreCustomer
            {
                BoughtBooks = new List<string>()
            };

            // Act
            var discountRate = customer.GetDiscountRate();

            // Assert
            Assert.AreEqual(0.05, discountRate);
        }

        [TestMethod]
        public void WhenCustomerHasBoughtMoreThanTenBooks_ThenReturnsHigherDiscountRate()
        {
            // Arrange
            var customer = new BookstoreCustomer
            {
                BoughtBooks = Enumerable.Repeat("Book", 15).ToList()
            };

            // Act
            var discountRate = customer.GetDiscountRate();

            // Assert
            Assert.AreEqual(0.1, discountRate);
        }
    }
}
