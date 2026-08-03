using Inventory.Models;

namespace Inventory.Interfaces;

internal interface IItemRepository
{
    ItemDto? Get(Guid id);
    List<ItemDto> GetAll();
    bool UpdateQuantity(UpdateQuantityDto updateQuantityDto);
}
