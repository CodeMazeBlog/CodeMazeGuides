using Inventory.Interfaces;
using Inventory.Models;

namespace Inventory.Services;

internal class ItemService(IItemRepository itemRepository) : IItemService
{
    public ItemDto? Get(Guid id)
    {
        return itemRepository.Get(id);
    }

    public List<ItemDto> GetAll()
    {
        return itemRepository.GetAll();
    }

    public bool UpdateQuantity(UpdateQuantityDto updateQuantityDto)
    {
        return itemRepository.UpdateQuantity(updateQuantityDto);
    }
}