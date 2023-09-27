using CodeMazeShop.Services.ProductCatalog.Entities;
using MongoDB.Driver;

namespace CodeMazeShop.Services.ProductCatalog.Data
{
    public class ProductCatalogContextSeed
    {
        public static void SeedData(IMongoCollection<Product> productCollection)
        {
            bool existProduct = productCollection.Find(p => true).Any();
            if (!existProduct)
            {
                 productCollection.InsertMany(GetPredefinedProducts());
            }
        }

        private static IEnumerable<Product> GetPredefinedProducts()
        {
            Random rnd = new();
            var products = new List<Product>();
            var categories = new List<Category>();
            for (var i = 0; i < 3; i++)
            {
                var categoryId = Guid.NewGuid().ToString();
                categories.Add(new Category
                {
                    CategoryId = categoryId,
                    Name = $"Category{i + 1}"
                });
            }

            for (var i = 0; i < 6; i++)
            {
                var productId = Guid.NewGuid().ToString();
                var categoryIndex = rnd.Next(0, 3);
                products.Add(new Product
                {
                    ProductId = productId,
                    Name = $"Test Product {i + 1}",
                    Description = $"Test Product {i + 1} - Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    Price = rnd.Next(10, 200),
                    ImageUrl = $"/img/test_product{i + 1}.png",
                    Category = categories[categoryIndex]
                });

            }

            return products;
        }
    }
}