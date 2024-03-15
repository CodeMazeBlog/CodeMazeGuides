using CodeMazeShop.Services.ProductCatalog.Data;
using CodeMazeShop.Services.ProductCatalog.Entities;
using MongoDB.Driver;

namespace CodeMazeShop.Services.ProductCatalog.Repositories;

public class ProductCatalogRepository : IProductCatalogRepository
{
    private readonly IProductCatalogContext _context;

    public ProductCatalogRepository(IProductCatalogContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetAllProducts() 
        => await _context
                    .Products
                    .Find(p => true)
                    .ToListAsync();    

    public async Task<IEnumerable<Category>> GetCategories() 
    {
        var products = await _context
            .Products
            .Find(p => true)
            .ToListAsync();

        return products
            .Select(p => p.Category)
            .DistinctBy(c => c.CategoryId);        
    }

    public async Task<Product> GetProduct(string id)
     => await _context
                 .Products
                 .Find(p => p.ProductId == id)
                 .FirstOrDefaultAsync();

    public async Task<IEnumerable<Product>> GetProductsByCategoryId(string? categoryId)
    {
        if (string.IsNullOrEmpty(categoryId))
        {
            return await GetAllProducts();
        }

        FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Category.CategoryId, categoryId);

        return await _context
                        .Products
                        .Find(filter)
                        .ToListAsync();
    }
}