using CodeMazeShop.DataContracts.ProductCatalog;
using CodeMazeShop.Utilities.Extensions;

namespace CodeMazeShop.Services.ShoppingCart.Facade;

public class ProductCatalogFacade : IProductCatalogFacade
{
    private readonly HttpClient _httpClient;
    public ProductCatalogFacade(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> GetProductName(Guid id)
    {
        var response = await _httpClient.GetAsync($"/api/products/{id}");
        var productFromCatalog =  await response.ReadContentAs<Product>();
        return productFromCatalog.Name;
    }
}
