using System.Collections.Concurrent;
using Common.Models;
using Common.Models.Messages;

namespace Microservice.ShoppingCartApi
{
    public interface ICheckoutProcessor
    {
        Task<CheckoutResponse> ProcessCheckoutAsync(CheckoutRequest request);

        BlockingCollection<CheckoutItem> CheckoutQueue { get; }
    }
}
