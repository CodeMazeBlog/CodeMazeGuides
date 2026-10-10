namespace PizzaShop.Api;

public sealed record PizzaStock(string Name, int Left);

public sealed record OrderConfirmation(string Pizza, int Quantity);

public static class KitchenErrors
{
    public static Error NotFound(string pizza) =>
        new("Pizza.NotFound", $"We don't make {pizza} pizza.", ErrorType.NotFound);

    public static Error SoldOut(string pizza, int left, int requested) =>
        new("Pizza.SoldOut", $"Only {left} {pizza} left, {requested} requested.", ErrorType.Conflict);
}

public static class Kitchen
{
    private static readonly Dictionary<string, int> Stock = new()
    {
        ["Margherita"] = 10,
        ["Diavola"] = 2
    };

    public static Result<PizzaStock> Check(string pizza) =>
        Stock.TryGetValue(pizza, out var left)
            ? new PizzaStock(pizza, left)
            : KitchenErrors.NotFound(pizza);

    public static Result<OrderConfirmation> Order(string pizza, int quantity)
    {
        if (!Stock.TryGetValue(pizza, out var left))
            return KitchenErrors.NotFound(pizza);

        if (quantity > left)
            return KitchenErrors.SoldOut(pizza, left, quantity);

        return new OrderConfirmation(pizza, quantity);
    }
}
