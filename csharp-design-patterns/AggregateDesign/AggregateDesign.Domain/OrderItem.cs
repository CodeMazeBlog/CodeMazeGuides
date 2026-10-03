namespace AggregateDesign.Domain;

public sealed class OrderItem
{
    internal OrderItem(string name, int quantity, decimal unitPrice)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(quantity);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(unitPrice);

        Name = name;
        Quantity = quantity;
        UnitPrice = unitPrice;
    }

    public string Name { get; private set; }
    public int Quantity { get; private set; }
    public decimal UnitPrice { get; private set; }

    internal void AddQuantity(int quantity) => Quantity += quantity;

    internal Result WithdrawQuantity(int quantity)
    {
        if (quantity >= Quantity)
            return OrderErrors.LastUnit(Name, Quantity);

        Quantity -= quantity;

        return Result.Success();
    }
}
