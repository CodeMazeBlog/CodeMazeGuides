using Common.Models;

namespace Monolith.ShoppingCartApi.Services.Interfaces
{
    public interface IReceiptGenerator
    {
        Task ProcessFailuresAsync(Guid customerId, CheckoutResponse response);
        Task GenerateAsync(Guid customerId, CheckoutResponse response, int amount);
    }
}
