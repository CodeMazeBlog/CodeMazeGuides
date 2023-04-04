using CodeMazeShop.Services.ProductCatalog.Entities;
using MongoDB.Driver;

namespace CodeMazeShop.Services.ProductCatalog.Data;

public class ProductCatalogContext : IProductCatalogContext
{
    public ProductCatalogContext(IConfiguration configuration)
    {
        var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
        
        var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

        Products = database.GetCollection<Product>("Products");
        
        ProductCatalogContextSeed.SeedData(Products);
    }

    public IMongoCollection<Product> Products { get; }
}