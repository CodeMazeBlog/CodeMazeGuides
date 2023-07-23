using Common.Models;

namespace Microservice.TaxCalculatorService
{
    public interface ICalculator
    {
        Task<int> CalculateTaxAsync(Guid customerId, IEnumerable<OrderLineItem> orderLineItems);
    }
}
