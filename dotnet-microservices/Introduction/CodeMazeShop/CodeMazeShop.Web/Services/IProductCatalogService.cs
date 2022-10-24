using CodeMazeShop.Web.Entities;

namespace CodeMazeShop.Web.Services;

public interface IProductCatalogService
{
    Task<IEnumerable<Product>> GetAll();
    Task<IEnumerable<Product>> GetByCategoryId(Guid categoryId);
    Task<Product> GetProduct(Guid id);
    Task<IEnumerable<Category>> GetCategories();
}