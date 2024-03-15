using Microsoft.Extensions.Configuration;
using Moq;
using PayStack.Net;

namespace SecretMgt.Tests
{
    public class PaymentServiceTests
    {
        [Fact]
        public void WhenValidOrderIdIsPassedInPayViaPaystack_ThenReturnTransactionInitializeResponse()
        {
            // Arrange
            var configuration = new Mock<IConfiguration>();
            configuration.Setup(x => x["Paystack:APIKey"]).Returns("sk_test_7f9a384e2dc15181cab8fb83db4fb332769fedbb");

            var paystackApi = new Mock<PayStackApi>("sk_test_7f9a384e2dc15181cab8fb83db4fb332769fedbb");
            var paymentService = new PaymentService(configuration.Object);
            paymentService = new PaymentService(configuration.Object);
            var orderId = 0;
            var email = "test@yopmail.com";

            // Act
            var result = paymentService.PayViaPaystack(orderId, email);

            // Assert
            Assert.NotNull(result);
        }
    }
}
