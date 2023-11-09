namespace App.DomainModels;

public abstract class Item
{
    public required Guid Id { get; set; }
    public required string Description { get; set; }
    public required decimal Price { get; set; }
}