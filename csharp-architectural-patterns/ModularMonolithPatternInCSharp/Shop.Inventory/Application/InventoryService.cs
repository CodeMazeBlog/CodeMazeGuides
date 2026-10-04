using Shop.Contracts.Inventory;
using Shop.Inventory.Domain;
using Shop.Shared;

namespace Shop.Inventory.Application;

internal sealed record ItemResponse(int Id, string Name, decimal UnitPrice, int InStock);

internal sealed class InventoryService(IItemRepository items) : IInventoryModule
{
    public async Task<Result<StockReservation>> ReserveStockAsync(
        int itemId, int quantity, CancellationToken cancellationToken = default)
    {
        var item = await items.GetByIdAsync(itemId, cancellationToken);
        if (item is null)
            return ItemErrors.NotFound(itemId);

        var reservation = item.Reserve(quantity);
        if (!reservation.IsSuccess)
            return reservation.Error!;

        await items.SaveChangesAsync(cancellationToken);

        return new StockReservation(item.Id, item.Name, item.UnitPrice, quantity);
    }

    public async Task<Result<ItemResponse>> GetItemAsync(
        int itemId, CancellationToken cancellationToken = default)
    {
        var item = await items.GetByIdAsync(itemId, cancellationToken);
        if (item is null)
            return ItemErrors.NotFound(itemId);

        return new ItemResponse(item.Id, item.Name, item.UnitPrice, item.InStock);
    }
}
