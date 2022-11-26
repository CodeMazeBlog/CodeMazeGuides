using System.Text.Json;

namespace ActionFuncInCSharp
{
    public class Product
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public ProductCategory ProductCategory { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Product product && product.Name == Name;
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
