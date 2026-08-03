using Common.Models;

namespace Microservice.PaymentProcessingService
{
    public class PaymentProcessor : IPaymentProcessor
    {
        private readonly ILogger _logger;
        public PaymentProcessor(ILogger<PaymentProcessor> logger)
        {
            _logger = logger;
        }
        public async Task<bool> ProcessAsync(Guid customerId, PaymentInfo paymentInfo, int amount)
        {
            //Simulates a slow payment processing via a third party payment gateway system
            await Task.Delay(2000);
            _logger.LogInformation($"Payment of {amount} has been processed for customer {customerId}");
            return true;
        }
    }
}
