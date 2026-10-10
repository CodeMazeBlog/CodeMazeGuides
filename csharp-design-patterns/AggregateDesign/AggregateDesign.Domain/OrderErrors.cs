namespace AggregateDesign.Domain;

public static class OrderErrors
{
    public static Error ItemsLocked =>
        new("Order.ItemsLocked", "Items can't change once payment has started.", ErrorType.Conflict);

    public static Error DuplicateItem(string name) =>
        new("Order.DuplicateItem", $"The order already has an item named '{name}'.", ErrorType.Conflict);

    public static Error ItemNotFound(string name) =>
        new("Order.ItemNotFound", $"The order has no item named '{name}'.", ErrorType.NotFound);

    public static Error LastUnit(string name, int quantity) =>
        new("Order.LastUnit", $"'{name}' has {quantity} left and needs at least one. Remove the item instead.", ErrorType.Conflict);

    public static Error Overpayment(decimal amountDue, decimal amount) =>
        new("Order.Overpayment", $"Only {amountDue} is due, but the payment is {amount}.", ErrorType.Conflict);

    public static Error Empty =>
        new("Order.Empty", "An order with no items can't ship.", ErrorType.Conflict);

    public static Error NotPaid(decimal amountDue) =>
        new("Order.NotPaid", $"The order can't ship while {amountDue} is still due.", ErrorType.Conflict);

    public static Error AlreadyShipped =>
        new("Order.AlreadyShipped", "The order has already shipped.", ErrorType.Conflict);
}
