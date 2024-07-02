namespace EfCoreInterceptors;

public class User : IAuditableEntity
{
    public long Id { get; protected set; }

    public string Name { get; set; }

    public string Email { get; set; }

    public DateTime Created { get; private set; }

    public DateTime Modified { get; private set; }

    public void AuditCreation(TimeProvider timeProvider)
    {
        var now = timeProvider.GetUtcNow().UtcDateTime;

        Created = now;
        Modified = now;
    }

    public void AuditModification(TimeProvider timeProvider)
    {
        Modified = timeProvider.GetUtcNow().UtcDateTime;
    }

    public void ValidateState()
    {
        if (string.IsNullOrWhiteSpace(Email))
            throw new ApplicationException("Invalid user state! Email should be provided!");
    }
}