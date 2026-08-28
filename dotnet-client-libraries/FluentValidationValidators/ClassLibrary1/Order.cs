namespace ClassLibrary1
{
    public class Order
    {
        public string CustomerName { get; set; }
        public int Price { get; set; }
        public string CustomerEmail { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public Product[] Products { get; set; }
    }

    public class Product
    {
        public string Name { get; set; }
    }

    public enum OrderStatus
    {
        Accepted,
        Processing,
        Complete
    }
}
