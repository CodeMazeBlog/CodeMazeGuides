using CodeMazeShop.Services.ProductCatalog.Entities;
using MongoDB.Driver;

namespace CodeMazeShop.Services.ProductCatalog.Data;

public interface IProductCatalogContext
{
    IMongoCollection<Product> Products { get; }
}
