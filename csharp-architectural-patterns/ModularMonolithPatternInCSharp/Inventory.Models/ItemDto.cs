namespace Inventory.Models;

public class ItemDto
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public int Quantity { get; set; }
    public bool IsOutOfStock => Quantity == 0;
    public double Price { get; set; }
}
