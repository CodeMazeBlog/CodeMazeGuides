namespace ObjectInitializersInCSharp
{
    public class Product
    {
        public string? Name { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }

        public void GetTotalPrice()
        {
            TotalPrice = Quantity * UnitPrice;
        }

        public Product() { }

        public Product(string name, int quantity, decimal unitPrice)
        {
            Name = name;
            Quantity = quantity;
            UnitPrice = unitPrice;

            GetTotalPrice();
        }
    }
}