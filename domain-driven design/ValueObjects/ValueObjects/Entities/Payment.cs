using ValueObjects.ValueObjects;

namespace ValueObjects.Entities;

public class Payment
{
    public Guid Id { get; private set; }
    public Money Quoted { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public Payment(Money quoted)
    {
        Id = Guid.NewGuid();
        Quoted = quoted;
        CreatedAt = DateTime.UtcNow;
    }
}