using CodeMazeShop.Services.ProductCatalog.Entities;

namespace CodeMazeShop.Services.ProductCatalog.Repositories;

public interface IProductCatalogRepository
{
    Task<IEnumerable<Product>> GetAllProducts();

    Task<IEnumerable<Product>> GetProductsByCategoryId(string categoryId);

    Task<Product> GetProduct(string id);

    Task<IEnumerable<Category>> GetCategories();
}
