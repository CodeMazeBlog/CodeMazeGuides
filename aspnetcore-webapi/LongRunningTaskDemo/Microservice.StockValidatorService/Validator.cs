using Common.Models;

namespace Microservice.StockValidatorService
{
    public class Validator : IValidator
    {
        private readonly ILogger _logger;

        public Validator(ILogger<Validator> logger)
        {
            _logger = logger;
        }
        public async Task<bool> ValidateAsync(IEnumerable<OrderLineItem> orderLineItems)
        {
            //Simulates a database/service lookup of stock availability for the line items
            await Task.Delay(1000);
            _logger.LogInformation("Stock is validated.");
            return true;
        }
    }
}
