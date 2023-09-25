namespace App;

public abstract class Item
{
    public Guid Id { get; set; }
    public required string Description { get; set; }
    public decimal Price { get; set; }
}

public class ClothingItem : Item
{
    public required string Size { get; set; }
    public required string Color { get; set; }
    public required string Material { get; set; }
}

public class ElectronicItem : Item
{
    public required string Model { get; set; }
    public required string Manufacturer { get; set; }
}