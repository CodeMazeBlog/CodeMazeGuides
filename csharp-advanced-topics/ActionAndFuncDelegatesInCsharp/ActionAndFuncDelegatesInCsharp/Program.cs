namespace ActionAndFuncDelegatesInCsharp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Action
            var seedProducts = ProductManager.Seed;
            seedProducts();

            var addProduct = ProductManager.Add;
            addProduct(5, "Tablet", true);
            addProduct(6, "Laptop", false);

            var remove = ProductManager.Remove;
            remove(5);

            foreach (var item in ProductManager.Products)
            {
                Console.WriteLine($"|{item.Id,3}|{item.Name,15}|{item.Exists,10}|");
            }

            // Func
            var getProduct = ProductManager.GetById;
            var product = getProduct(1);
            Console.WriteLine($"Product with id 1 is: {product.Name}");
        }
    }
}
