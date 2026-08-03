namespace Inventory.Models;

public class UpdateQuantityDto
{
    public Guid ItemId { get; set; }
    public int Amount { get; set; }
}
