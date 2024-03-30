using Inventory.Models;
using Inventory.Repositories;

namespace Inventory.Services;

internal class ItemService(IItemRepository itemRepository) : IItemService
{
    private readonly IItemRepository _itemRepository = itemRepository;

    public ItemDto? Get(Guid id)
    {
        return _itemRepository.Get(id);
    }

    public List<ItemDto> GetAll()
    {
        return _itemRepository.GetAll();
    }

    public bool UpdateQuantity(UpdateQuantityDto updateQuantityDto)
    {
        return _itemRepository.UpdateQuantity(updateQuantityDto);
    }
}

public interface IItemService
{
    ItemDto? Get(Guid id);
    List<ItemDto> GetAll();
    bool UpdateQuantity(UpdateQuantityDto updateQuantityDto);
}
