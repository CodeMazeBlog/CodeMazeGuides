namespace ObjectInitializersInCSharp
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Using Object Initializer
            var product = new Product
            {
                Name = "Book",
                Quantity = 15,
                UnitPrice = 17.99m
            };

            //Using a constructor
            product = new Product();
            product.Name = "Book";
            product.Quantity = 15;
            product.UnitPrice = 17.99m;
        }
    }
}