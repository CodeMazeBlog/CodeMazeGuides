using Common.Models;

namespace Monolith.ShoppingCartApi.Coordinators
{
    public interface ICheckoutCoordinator
    {
        Task<CheckoutResponse> ProcessCheckoutAsync(CheckoutRequest request);
    }
}
