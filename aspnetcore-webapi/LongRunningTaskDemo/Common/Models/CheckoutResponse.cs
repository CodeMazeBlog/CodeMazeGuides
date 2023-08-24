namespace Common.Models
{
    public class CheckoutResponse
    {
        public Guid OrderId { get; set; }
               
        public OrderStatus OrderStatus { get; set; }

        public string? Message { get; set; }
    }
}