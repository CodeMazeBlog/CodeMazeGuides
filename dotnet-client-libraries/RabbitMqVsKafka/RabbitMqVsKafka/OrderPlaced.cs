namespace RabbitMqVsKafka;

public record OrderPlaced(int OrderId, string Customer, decimal Total)
{
    public static IReadOnlyList<OrderPlaced> Samples { get; } =
    [
        new(1001, "Ana", 49.90m),
        new(1002, "Ben", 120.00m),
        new(1003, "Chloe", -15.00m),
        new(1004, "Dan", 75.50m),
        new(1005, "Eva", 9.99m)
    ];

    public bool CanBeBilled => Total > 0;
}
