namespace ActionAndFuncDelegatesInCsharp
{
    public static class ProductManager
    {
        public static List<Product> Products = new();
        public static void Seed()
        {
            Products.AddRange(new List<Product> {
                 new Product(1, "Mouse", true),
                 new Product(2, "Hard Drive", true),
                 new Product(3, "Keyboard", false),
                 new Product(4, "EarPods", false)
            });
        }
        public static Product GetById(int id) => Products.FirstOrDefault(c => c.Id == id);
        public static void Add(int id, string name, bool exists)
        {
            if (!Products.Any(c => c.Id == id))
            {
                Products.Add(new Product(id, name, exists));
            }
            else
            {
                throw new Exception($"A product with Id {id} already exists in the list.");
            }
        }
        public static void Remove(int id)
        {
            var product = GetById(id);
            if (product is not null)
            {
                Products.Remove(product);
            }
            else
            {
                throw new Exception($"There is no product with Id {id} in the list.");
            }
        }
    }
}
