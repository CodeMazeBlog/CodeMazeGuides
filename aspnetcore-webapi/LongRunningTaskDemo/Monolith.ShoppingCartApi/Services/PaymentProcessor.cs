using Common.Models;
using Monolith.ShoppingCartApi.Services.Interfaces;

namespace Monolith.ShoppingCartApi.Services
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
            await Task.Delay(20);
            _logger.LogInformation($"Payment of {amount} has been processed for customer {customerId}");
            return true;
        }
    }
}