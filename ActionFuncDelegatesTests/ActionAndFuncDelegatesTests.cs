namespace ActionFuncDelegatesTests
{
    [TestClass]
    public class ActionAndFuncDelegatesTests
    {
        [TestMethod]
        public void WhenCustomerInfo_ThenWelcomeMessageIsDisplayed()
        {
            // Arrange
            string expectedMessage = "Welcome to our restaurant!";
            string? actualMessage = null;

            // Act
            Action<string> customerInfo = ActionAndFuncDelegates.InfoMethod;
            customerInfo += (info) => actualMessage = info;
            customerInfo.Invoke(expectedMessage);

            // Assert
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [TestMethod]
        public void WhenCalculateOrder_ThenCorrectOrderTotalIsReturned()
        {
            // Arrange
            decimal mealOne = 4.76M;
            decimal mealTwo = 3.12M;
            decimal mealThree = 5.77M;
            decimal expectedTotal = 13.65M;

            // Act
            Func<decimal, decimal, decimal, decimal> orderTotal = ActionAndFuncDelegates.CalculateOrder;
            decimal actualTotal = orderTotal.Invoke(mealOne, mealTwo, mealThree);

            // Assert
            Assert.AreEqual(expectedTotal, actualTotal);
        }

        [TestMethod]
        public void WhenCalculateOrderWithLambda_ThenCorrectYesterdaysOrderTotalIsReturned()
        {
            // Arrange
            decimal mealOne = 13.5M;
            decimal mealTwo = 6.3M;
            decimal mealThree = 21.7M;
            decimal expectedTotal = 41.5M;

            // Act
            Func<decimal, decimal, decimal, decimal> lambdaCalculateOrder = (m1, m2, m3) => m1 + m2 + m3;
            decimal actualTotal = lambdaCalculateOrder.Invoke(mealOne, mealTwo, mealThree);

            // Assert
            Assert.AreEqual(expectedTotal, actualTotal);
        }

        [TestMethod]
        public void WhenCustomerInfoIsWithLambda_ThenThankYouMessageIsDisplayed()
        {
            // Arrange
            string expectedMessage = "Thank you for your order!";
            string? actualMessage = null;

            // Act
            Action<string> lambdaCustomerInfo = (info) => actualMessage = info;
            lambdaCustomerInfo.Invoke(expectedMessage);

            // Assert
            Assert.AreEqual(expectedMessage, actualMessage);
        }
    }
}