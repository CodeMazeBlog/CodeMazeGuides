using Common.Models;
using Monolith.ShoppingCartApi.Services.Interfaces;

namespace Monolith.ShoppingCartApi.Services
{
    public class TaxCalculator : ITaxCalculator
    {
        private readonly Random _random = new();
        private readonly ILogger _logger;
        
        public TaxCalculator(ILogger<TaxCalculator> logger)
        {
            _logger = logger;
        }

        public async Task<int> CalculateTaxAsync(Guid customerId, IEnumerable<OrderLineItem> orderLineItems)
        {
            await Task.Delay(50);
            _logger.LogInformation($"Customer lookup completed for customer {customerId}.");

            await Task.Delay(50);
            var tax = _random.Next(1, 200);
            _logger.LogInformation($"Tax value calculated for customer is {tax}.");

            return tax;
        }
    }
}