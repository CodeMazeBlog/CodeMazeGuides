namespace ActionAndFuncDelegates
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public List<Product>? Products { get; set; }
    }

    public class Product
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string ProductName { get; set; }
    }

    public class OrderDetails
    {
        public Order Order { get; set; }
        public decimal Sum { get; set; }
        public decimal Discount { get; set; }
    }
}