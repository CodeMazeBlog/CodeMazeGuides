using Common.Models;
using Monolith.ShoppingCartApi.Services.Interfaces;

namespace Monolith.ShoppingCartApi.Services
{
    public class StockValidator : IStockValidator
    {
        private readonly ILogger _logger;

        public StockValidator(ILogger<StockValidator> logger)
        {
            _logger = logger;
        }
        public async Task<bool> ValidateAsync(IEnumerable<OrderLineItem> orderLineItems)
        {
            await Task.Delay(50);
            _logger.LogInformation("Stock is validated.");
            return true;
        }
    }
}