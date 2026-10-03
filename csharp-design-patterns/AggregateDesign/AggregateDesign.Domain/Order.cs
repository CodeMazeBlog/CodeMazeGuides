namespace AggregateDesign.Domain;

public sealed class Order
{
    private readonly List<OrderItem> _items = [];

    private Order(DateTime createdAtUtc)
    {
        CreatedAtUtc = createdAtUtc;
        Status = OrderStatus.PendingPayment;
    }

    public long Id { get; private set; }
    public DateTime CreatedAtUtc { get; private set; }
    public DateTime? ShippedAtUtc { get; private set; }
    public decimal PaidAmount { get; private set; }
    public OrderStatus Status { get; private set; }

    public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();

    public decimal Total => _items.Sum(item => item.Quantity * item.UnitPrice);
    public decimal AmountDue => Total - PaidAmount;

    public static Order Create(TimeProvider clock) => new(clock.GetUtcNow().UtcDateTime);

    public Result AddItem(string name, int quantity, decimal unitPrice)
    {
        if (PaidAmount > 0)
            return OrderErrors.ItemsLocked;

        if (FindItem(name) is not null)
            return OrderErrors.DuplicateItem(name);

        _items.Add(new OrderItem(name, quantity, unitPrice));

        return Result.Success();
    }

    public Result RemoveItem(string name)
    {
        if (PaidAmount > 0)
            return OrderErrors.ItemsLocked;

        var item = FindItem(name);
        if (item is null)
            return OrderErrors.ItemNotFound(name);

        _items.Remove(item);

        return Result.Success();
    }

    public Result AddQuantity(string name, int quantity)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(quantity);

        if (PaidAmount > 0)
            return OrderErrors.ItemsLocked;

        var item = FindItem(name);
        if (item is null)
            return OrderErrors.ItemNotFound(name);

        item.AddQuantity(quantity);

        return Result.Success();
    }

    public Result WithdrawQuantity(string name, int quantity)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(quantity);

        if (PaidAmount > 0)
            return OrderErrors.ItemsLocked;

        var item = FindItem(name);
        if (item is null)
            return OrderErrors.ItemNotFound(name);

        return item.WithdrawQuantity(quantity);
    }

    public Result AddPayment(decimal amount)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(amount);

        if (amount > AmountDue)
            return OrderErrors.Overpayment(AmountDue, amount);

        PaidAmount += amount;

        if (AmountDue == 0)
            Status = OrderStatus.ReadyForShipping;

        return Result.Success();
    }

    public Result Ship(TimeProvider clock)
    {
        if (_items.Count == 0)
            return OrderErrors.Empty;

        if (Status == OrderStatus.InTransit)
            return OrderErrors.AlreadyShipped;

        if (Status != OrderStatus.ReadyForShipping)
            return OrderErrors.NotPaid(AmountDue);

        ShippedAtUtc = clock.GetUtcNow().UtcDateTime;
        Status = OrderStatus.InTransit;

        return Result.Success();
    }

    private OrderItem? FindItem(string name) => _items.Find(item => item.Name == name);
}
