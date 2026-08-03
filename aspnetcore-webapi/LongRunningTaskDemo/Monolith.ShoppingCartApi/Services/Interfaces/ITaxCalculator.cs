using Common.Models;

namespace Monolith.ShoppingCartApi.Services.Interfaces
{
    public interface ITaxCalculator
    {
        Task<int> CalculateTaxAsync(Guid customerId, IEnumerable<OrderLineItem> orderLineItems);
    }
}
