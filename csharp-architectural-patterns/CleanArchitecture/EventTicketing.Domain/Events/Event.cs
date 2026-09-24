using EventTicketing.Domain.Common;

namespace EventTicketing.Domain.Events;

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
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException("An event needs a name.");

        if (capacity <= 0)
            throw new DomainException("Capacity must be positive.");

        return new Event(name, capacity);
    }

    public Result Reserve(int quantity)
    {
        if (quantity <= 0)
            throw new DomainException("Quantity must be positive.");

        if (quantity > TicketsLeft)
            return EventErrors.SoldOut(TicketsLeft, quantity);

        TicketsSold += quantity;

        return Result.Success();
    }
}
