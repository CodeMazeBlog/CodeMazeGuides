namespace App.Models;

public class Store
{
    public required string Name { get; set; }
    public required List<Item> Items { get; set; }
}