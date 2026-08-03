using Inventory.Models;

namespace Inventory.Entities;

internal class Item
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Name { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }

    public ItemDto ToDto()
    {
        return new ItemDto
        {
            Id = Id,
            Name = Name,
            Quantity = Quantity,
            Price = Price
        };
    }
}
