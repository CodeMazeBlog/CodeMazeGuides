using CodeMazeShop.Web.Entities;
using CodeMazeShop.Web.Repositories;

namespace CodeMazeShop.Web.Services;

public class ProductCatalogService : IProductCatalogService
{
    private readonly IProductCatalogRepository _productCatalogRepository;
    public ProductCatalogService(IProductCatalogRepository productCatalogRepository)
    {
        _productCatalogRepository = productCatalogRepository;
    }
    public Task<IEnumerable<Product>> GetAll() 
        => _productCatalogRepository.GetAllProducts();

    public Task<IEnumerable<Product>> GetByCategoryId(Guid categoryId) 
        => _productCatalogRepository.GetProductsByCategoryId(categoryId);        

    public Task<IEnumerable<Category>> GetCategories() 
        => _productCatalogRepository.GetCategories();

    public Task<Product> GetProduct(Guid id) 
        => _productCatalogRepository.GetProduct(id);
   
}
