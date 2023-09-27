namespace App.DomainModels;

public abstract class Item
{
    public Guid Id { get; set; }
    public required string Description { get; set; }
    public decimal Price { get; set; }
}