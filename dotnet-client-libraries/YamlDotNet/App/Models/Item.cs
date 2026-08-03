namespace App.Models;

public class Item
{
    public required string Name { get; set; }
    public decimal Price { get; set; }
    public required Manufacturer Manufacturer { get; set; }
}