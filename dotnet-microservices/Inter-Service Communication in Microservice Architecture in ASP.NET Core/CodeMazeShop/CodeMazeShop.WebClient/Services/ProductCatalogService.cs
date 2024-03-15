using CodeMazeShop.DataContracts.ProductCatalog;
using CodeMazeShop.Utilities.Extensions;

namespace CodeMazeShop.WebClient.Services;

public class ProductCatalogService : IProductCatalogService
{
    private readonly HttpClient _httpClient;
    public ProductCatalogService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<IEnumerable<Product>> GetAll()
    {
        var response = await _httpClient.GetAsync("/api/products");
        return await response.ReadContentAs<List<Product>>();
    }

    public async Task<IEnumerable<Product>> GetByCategoryId(Guid categoryId)
    {
        var response = await _httpClient.GetAsync($"/api/products/?categoryId ={categoryId}");
        return await response.ReadContentAs<List<Product>>();
    }

    public async Task<IEnumerable<Category>> GetCategories()
    {
        var response = await _httpClient.GetAsync("/api/categories");
        return await response.ReadContentAs<List<Category>>();
    }

    public async Task<Product> GetProduct(Guid id)
    {
        var response = await _httpClient.GetAsync($"/api/products/{id}");
        return await response.ReadContentAs<Product>();
    }

}
