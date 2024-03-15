namespace SagaPattern.Models
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public decimal Price { get; set; }
        public OrderStatus Status { get; set; }
    }
}
