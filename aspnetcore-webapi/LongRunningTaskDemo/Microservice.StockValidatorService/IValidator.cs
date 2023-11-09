using Common.Models;

namespace Microservice.StockValidatorService
{
    public interface IValidator
    {
        Task<bool> ValidateAsync(IEnumerable<OrderLineItem> orderLineItems);
    }
}
