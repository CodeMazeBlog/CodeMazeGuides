using Shop.Inventory.Domain;

namespace Shop.Inventory.Application;

internal interface IItemRepository
{
    Task<Item?> GetByIdAsync(int itemId, CancellationToken cancellationToken = default);

    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}
