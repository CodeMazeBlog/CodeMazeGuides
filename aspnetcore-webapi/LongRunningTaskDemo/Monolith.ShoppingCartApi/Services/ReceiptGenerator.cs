using Common.Models;
using Monolith.ShoppingCartApi.Services.Interfaces;

namespace Monolith.ShoppingCartApi.Services
{
    public class ReceiptGenerator : IReceiptGenerator
    {
        private readonly ILogger _logger;
        public ReceiptGenerator(ILogger<ReceiptGenerator> logger)
        {
            _logger = logger;
        }
        public async Task GenerateAsync(Guid customerId, CheckoutResponse response, int amount)
        {
            await Task.Delay(50);
            _logger.LogInformation("Receipt Generated and Order Status persisted in DB.");

            await Task.Delay(50);
            _logger.LogInformation("Email is sent with Order Status and receipt.");
        }

        public async Task ProcessFailuresAsync(Guid customerId, CheckoutResponse response)
        {
            await Task.Delay(50);
            _logger.LogInformation("Failure Order Status and reason persisted in DB.");

            await Task.Delay(50);
            _logger.LogInformation("Email is sent with Order Status and failure reason.");
        }
    }
}
