using Inventory.Models;

namespace Inventory.Interfaces;

public interface IItemService
{
    ItemDto? Get(Guid id);
    List<ItemDto> GetAll();
    bool UpdateQuantity(UpdateQuantityDto updateQuantityDto);
}