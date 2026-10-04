using Shop.Inventory.Application;
using Shop.Inventory.Domain;

namespace Shop.Inventory.Infrastructure;

internal sealed class InMemoryItemRepository : IItemRepository
{
    private readonly Dictionary<int, Item> _items = new()
    {
        [1] = new Item(1, "Mechanical keyboard", 89.99m, inStock: 10),
        [2] = new Item(2, "Rubber duck", 4.99m, inStock: 2)
    };

    public Task<Item?> GetByIdAsync(int itemId, CancellationToken cancellationToken = default) =>
        Task.FromResult(_items.GetValueOrDefault(itemId));

    public Task SaveChangesAsync(CancellationToken cancellationToken = default) =>
        Task.CompletedTask;
}
