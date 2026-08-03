namespace AggregateDesign.Domain;

public class OrderItem
{
    public long OrderItemId { get; private set; }

    public string ItemName { get; private set; }

    public uint Quantity { get; private set; }

    public decimal UnitPrice { get; private set; }

    private OrderItem() {}

    internal OrderItem(string itemName, uint quantity, decimal unitPrice)
    {
        if (string.IsNullOrEmpty(itemName))
            throw new ArgumentException($"'{nameof(itemName)}' cannot be null or empty.", nameof(itemName));

        if (quantity == 0)
            throw new ArgumentException("Quantity must be at least one.", nameof(quantity));

        if (unitPrice <= 0)
            throw new ArgumentException("Unit price must be above zero.", nameof(unitPrice));

        ItemName = itemName;
        Quantity = quantity;
        UnitPrice = unitPrice;
    }

    internal void AddQuantity(uint quantity)
    {
        this.Quantity += quantity;
    }

    internal void WithdrawQuantity(uint quantity)
    {
        if (this.Quantity - quantity <= 0)
            throw new InvalidOperationException("Can't remove all units from an order item. Remove the entire order item instead.");

        this.Quantity -= quantity;
    }
}