namespace SwashbuckleVsNSwag.Models.Orders
{
    public class Order
    {
        public Guid OrderId { get; set; }

        public Guid CustomerId { get; set; }

        public List<OrderItem> Basket { get; set; }
    }
}
