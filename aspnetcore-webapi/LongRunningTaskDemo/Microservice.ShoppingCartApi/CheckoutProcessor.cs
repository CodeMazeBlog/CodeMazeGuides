using System.Collections.Concurrent;
using Common.Models;
using Common.Models.Messages;

namespace Microservice.ShoppingCartApi
{
    public class CheckoutProcessor : ICheckoutProcessor
    {
        public BlockingCollection<CheckoutItem> CheckoutQueue { get; }

        public CheckoutProcessor()
        {
            CheckoutQueue = new BlockingCollection<CheckoutItem>(new ConcurrentQueue<CheckoutItem>());
        }
        public Task<CheckoutResponse> ProcessCheckoutAsync(CheckoutRequest request)
        {
            var response = new CheckoutResponse
            {
                OrderId = Guid.NewGuid(),
                OrderStatus = OrderStatus.Inprogress,
                Message = "Your order is in progress and you will receive an email with all details once the processing completes."
            };

            var item = new CheckoutItem
            {
                OrderId = response.OrderId,
                Request = request
            };

            CheckoutQueue.Add(item);

            return Task.FromResult(response);
        }
    }
}