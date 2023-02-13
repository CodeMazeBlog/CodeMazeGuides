namespace ActionAndFuncDelegatesInCSharp
{
    public class Program
    {
        readonly static Func<decimal, decimal, decimal> calculateVat = (price, percentage) => Math.Round((percentage / price) * 100, 2);
        readonly static List<Product> products = new()
        {
            new() { Name = "Laptop", Price = 999.95M },
            new() { Name = "Car", Price = 15000 },
            new() { Name = "TV", Price = 599 }
        };

        public static void Main()
        {
            foreach (var product in products)
            {
                var vat = calculateVat(product.Price, 21);
                PrintMessage($"{product.Name} {product.Price} ({product.Price + vat} incl. VAT)");
            }
        }

        public static void PrintMessage(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                throw new ArgumentException($"{nameof(message)} cannot be NULL or empty");
            }

            Console.WriteLine(message);
        }
    }
}