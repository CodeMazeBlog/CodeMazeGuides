using Common.Models;

namespace Monolith.ShoppingCartApi
{
    public class QueueItem
    {
        public Guid OrderId { get; set; }

        public CheckoutRequest? Request { get; set; }
    }
}