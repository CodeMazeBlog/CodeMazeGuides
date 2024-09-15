using Inventory.Models;

namespace Order.Interfaces;

public interface IInventoryRestClient
{
    Task<ItemDto?> GetItem(Guid id);
}
