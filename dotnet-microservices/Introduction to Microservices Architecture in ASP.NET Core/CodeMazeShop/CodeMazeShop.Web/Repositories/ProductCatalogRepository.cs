using CodeMazeShop.Web.Entities;

namespace CodeMazeShop.Web.Repositories;

public class ProductCatalogRepository : IProductCatalogRepository
{
    private readonly Dictionary<Guid, Product> _products = new();
    private readonly Dictionary<Guid, Category> _categories = new();
    private Random _rnd = new();

    public ProductCatalogRepository()
    {
        InitializeProductCatalogStore();
    }
    public async Task<IEnumerable<Product>> GetAllProducts()
        => await Task.FromResult(_products.Values.ToList());

    public async Task<IEnumerable<Product>> GetProductsByCategoryId(Guid categoryId)
        => await Task.FromResult(_products.Values.Where(p => p.CategoryId == categoryId));

    public async Task<Product> GetProduct(Guid id)
        => await Task.FromResult(_products.GetValueOrDefault(id));

    public async Task<IEnumerable<Category>> GetCategories()
        => await Task.FromResult(_categories.Values.ToList());

    private void InitializeProductCatalogStore()
    {        
        for(var i = 0;i < 3; i++)
        {
            var categoryId = Guid.NewGuid();
            _categories.Add(categoryId, new Category
            {
                CategoryId = categoryId,
                Name = $"Category{i + 1}"
            });
        }

        for(var i = 0; i< 6; i++)
        {
            var productId = Guid.NewGuid();
            var categoryIndex = _rnd.Next(0, 3);
            _products.Add(productId, new Product
            {
                ProductId = productId,
                Name = $"Test Product {i + 1}",
                Description = $"Test Product {i + 1} - Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                Price = _rnd.Next(10, 200),
                ImageUrl = $"/img/test_product{i + 1}.png",
                CategoryId = _categories.Keys.ElementAt(categoryIndex),
                CategoryName = _categories.Values.ElementAt(categoryIndex).Name
            });           
            
        }        
    }
}