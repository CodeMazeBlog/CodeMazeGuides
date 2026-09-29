namespace EventTicketing.Domain;

public sealed class Event
{
    private Event(string name, int capacity)
    {
        Name = name;
        Capacity = capacity;
    }

    public int Id { get; private set; }
    public string Name { get; private set; }
    public int Capacity { get; private set; }
    public int TicketsSold { get; private set; }

    public int TicketsLeft => Capacity - TicketsSold;

    public static Event Create(string name, int capacity)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(capacity);

        return new Event(name, capacity);
    }

    public Result Reserve(int quantity)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(quantity);

        if (quantity > TicketsLeft)
            return EventErrors.SoldOut(TicketsLeft, quantity);

        TicketsSold += quantity;

        return Result.Success();
    }
}
