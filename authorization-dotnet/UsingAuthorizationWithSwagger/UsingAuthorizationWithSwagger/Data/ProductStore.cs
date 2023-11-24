using UsingAuthorizationWithSwagger.Models;

namespace UsingAuthorizationWithSwagger.Data
{
    public static class ProductStore
    {
        private static Product[] products = new Product[]
        {
            new Product { Id = 1, Name = "Rubber duck"},
            new Product { Id = 2, Name = "Flip flop"},
            new Product { Id = 3, Name = "Magic Wand"},
            new Product { Id = 4, Name = "Glitter pen"}
        };

        public static IEnumerable<Product> GetProducts()
        {
            return products;
        }

        public static Product? GetProduct(int id)
        {
            foreach (var product in products)
            {
                if (product.Id == id)   
                    return product;
            }
            return null;
        }
    }
}
