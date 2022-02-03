namespace ActionAndFuncDemo.BusinessModels
{
    /// <summary>
    /// A record type to hold the items data
    /// </summary>
    /// <param name="Id">Unique Identifier</param>
    /// <param name="Name">Name of the Item</param>
    /// <param name="Price">Price per Metric</param>
    /// <param name="Quantity">Stock Quantity</param>
    public class Item
    {
        public Item(int id, string name, decimal price, decimal quantity)
        {
            Id = id;
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
    }
}
