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
            product.GetTotalPrice();

            //Using a constructor
            product = new Product();
            product.Name = "Book";
            product.Quantity = 15;
            product.UnitPrice = 17.99m;

            //Using object initializers with LINQ
            var products = new List<Product> {
                new Product {Name = "Toy", UnitPrice = 5.99m},
                new Product {Name = "Pen", UnitPrice = 7.99m},
                new Product {Name = "Magazine", UnitPrice = 25.99m},
                new Product {Name = "Calculator", UnitPrice = 67.99m},
            };

            var cheapProducts = products.Where(p => p.UnitPrice < 10.00m)
                                .Select(p => new { p.Name, p.UnitPrice })
                                .ToList();

            //Setting Immutable properties
            var partner = new LogisticsPartner(67845, "DHL");

            var toyota = new Car("Toyota", "Corolla") { Description = "A fairly basic sedan." };
            Console.WriteLine(toyota.Description);

            var honda = new Car("Honda", "Civic");
            Console.WriteLine(honda.Description);

            //Using Expression-bodied members
            var person = new Person { Name = "Sam", Age = 30 };
            Console.WriteLine(person.Description);
        }
    }
}