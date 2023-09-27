namespace Common.Models
{
    public class CheckoutRequest
    {
        public Guid CustomerId { get; set; }

        public IEnumerable<OrderLineItem>? LineItems { get; set; }

        public PaymentInfo? PaymentInfo { get; set; }
    }
}