namespace Common.Models
{
    public class OrderLineItem
    {
        public Guid ProductId { get; set; }

        public string? ProductName { get; set; }

        public int Price { get; set; }

        public int Quantity { get; set; }
    }
}