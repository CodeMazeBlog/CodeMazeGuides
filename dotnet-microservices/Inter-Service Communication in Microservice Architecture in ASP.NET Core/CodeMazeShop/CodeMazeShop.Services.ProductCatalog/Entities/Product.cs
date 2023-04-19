using MongoDB.Bson.Serialization.Attributes;
namespace CodeMazeShop.Services.ProductCatalog.Entities;

public class Product
{
    [BsonId]
    public string ProductId { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public int Price { get; set; }

    public string ImageUrl { get; set; }

    public Category Category { get; set; }
}
