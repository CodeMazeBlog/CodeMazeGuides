using CodeMazeShop.Web.Entities;

namespace CodeMazeShop.Web.Repositories;

public interface IProductCatalogRepository
{
    Task<IEnumerable<Product>> GetAllProducts();

    Task<IEnumerable<Product>> GetProductsByCategoryId(Guid categoryId);

    Task<Product> GetProduct(Guid id);

    Task<IEnumerable<Category>> GetCategories();
}