using Common.Models;

namespace Monolith.ShoppingCartApi.Services.Interfaces
{
    public interface IStockValidator
    {
        Task<bool> ValidateAsync(IEnumerable<OrderLineItem> orderLineItems); 
    }
}
