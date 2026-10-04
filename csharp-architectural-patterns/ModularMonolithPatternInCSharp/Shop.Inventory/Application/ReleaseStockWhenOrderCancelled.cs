using Shop.Contracts.Orders;
using Shop.Shared;

namespace Shop.Inventory.Application;

internal sealed class ReleaseStockWhenOrderCancelled(IItemRepository items)
    : IIntegrationEventHandler<OrderCancelled>
{
    public async Task HandleAsync(
        OrderCancelled integrationEvent, CancellationToken cancellationToken = default)
    {
        var item = await items.GetByIdAsync(integrationEvent.ItemId, cancellationToken)
            ?? throw new InvalidOperationException($"Item {integrationEvent.ItemId} was not found.");

        item.Release(integrationEvent.Quantity);

        await items.SaveChangesAsync(cancellationToken);
    }
}
