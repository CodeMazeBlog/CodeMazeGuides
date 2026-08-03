using Common.Models;

namespace Monolith.ShoppingCartApi.Services.Interfaces
{
    public interface IPaymentProcessor
    {
        Task<bool> ProcessAsync(Guid customerId, PaymentInfo paymentInfo, int amount);
    }
}
