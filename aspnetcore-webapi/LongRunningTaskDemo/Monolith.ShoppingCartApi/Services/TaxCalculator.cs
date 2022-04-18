using Common.Models;
using Monolith.ShoppingCartApi.Services.Interfaces;

namespace Monolith.ShoppingCartApi.Services
{
    public class TaxCalculator : ITaxCalculator
    {
        private Random _random = new Random();
        private readonly ILogger _logger;
        
        public TaxCalculator(ILogger<TaxCalculator> logger)
        {
            _logger = logger;
        }

        public async Task<int> CalculateTaxAsync(Guid CustomerId, IEnumerable<OrderLineItem> orderLineItems)
        {
            //Simulate Customer lookup from database/service. The customer address can be used for tax calculation
            await Task.Delay(500);
            _logger.LogInformation($"Customer lookup completed for customer {CustomerId}.");

            //Simulate complex tax calculation for all line items
            await Task.Delay(500);
            var tax = _random.Next(1, 200);

            _logger.LogInformation($"Tax value calculated for customer is {tax}.");

            return tax;
        }
    }
}