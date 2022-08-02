using Common.Models;

namespace Monolith.ShoppingCartApi.Coordinators
{
    public class CheckoutCoordinatorV3 : ICheckoutCoordinator
    {       
        private readonly IObserver<QueueItem> _checkoutStream;

        public CheckoutCoordinatorV3(IObserver<QueueItem> checkoutStream)
        {
            _checkoutStream = checkoutStream;
        }

        public Task<CheckoutResponse> ProcessCheckoutAsync(CheckoutRequest request)
        {
            var response = new CheckoutResponse
            {
                OrderId = Guid.NewGuid(),
                OrderStatus = OrderStatus.Inprogress,
                Message = "Your order is in progress and you will receive an email with all details once the processing completes."
            };

            var queueItem = new QueueItem
            {
                OrderId = response.OrderId,
                Request = request
            };

            _checkoutStream.OnNext(queueItem);

            return Task.FromResult(response);
        }
    }        
}