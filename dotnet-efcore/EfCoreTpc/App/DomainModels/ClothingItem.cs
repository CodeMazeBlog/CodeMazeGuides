namespace App.DomainModels;

public class ClothingItem : Item
{
    public required string Size { get; set; }
    public required string Color { get; set; }
    public required string Material { get; set; }
}