using Microsoft.Extensions.Configuration;
using Moq;
using PayStack.Net;

namespace SecretMgt.Tests
{
    public class OrderServiceTests
    {
        [Fact]
        public void WhenValidOrderIdIsPassedInPayViaPaystack_ThenReturnTransactionInitializeResponse()
        {
            // Arrange
            var configuration = new Mock<IConfiguration>();
            configuration.Setup(x => x["Paystack:APIKey"]).Returns("your-api-key");

            var paystackApi = new Mock<PayStackApi>("your-api-key");
            var orderService = new OrderService(configuration.Object);
            orderService = new OrderService(configuration.Object);
            var orderId = 0;
            var email = "test@example.com";

            // Act
            var result = orderService.PayViaPaystack(orderId, email);

            // Assert
            Assert.NotNull(result);
        }
    }
}
