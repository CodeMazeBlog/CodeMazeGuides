using Shop.Shared;

namespace Shop.Contracts.Inventory;

public interface IInventoryModule
{
    Task<Result<StockReservation>> ReserveStockAsync(
        int itemId, int quantity, CancellationToken cancellationToken = default);
}

public sealed record StockReservation(int ItemId, string ItemName, decimal UnitPrice, int Quantity);
