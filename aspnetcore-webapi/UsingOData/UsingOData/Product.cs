using System.ComponentModel.DataAnnotations;

namespace UsingOData
{
    public class Product
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
    }
}
