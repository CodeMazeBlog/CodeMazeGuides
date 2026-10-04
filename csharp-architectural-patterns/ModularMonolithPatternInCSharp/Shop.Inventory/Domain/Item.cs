using Shop.Shared;

namespace Shop.Inventory.Domain;

internal sealed class Item(int id, string name, decimal unitPrice, int inStock)
{
    public int Id { get; } = id;
    public string Name { get; } = name;
    public decimal UnitPrice { get; } = unitPrice;
    public int InStock { get; private set; } = inStock;

    public Result Reserve(int quantity)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(quantity);

        if (quantity > InStock)
            return ItemErrors.OutOfStock(Id, InStock, quantity);

        InStock -= quantity;

        return Result.Success();
    }

    public void Release(int quantity)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(quantity);

        InStock += quantity;
    }
}

internal static class ItemErrors
{
    public static Error NotFound(int itemId) =>
        new("Item.NotFound", $"Item {itemId} was not found.", ErrorType.NotFound);

    public static Error OutOfStock(int itemId, int inStock, int requested) =>
        new("Item.OutOfStock", $"Only {inStock} of item {itemId} left, {requested} requested.", ErrorType.Conflict);
}
