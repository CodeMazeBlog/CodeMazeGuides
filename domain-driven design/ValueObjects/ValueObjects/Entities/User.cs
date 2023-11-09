using ValueObjects.ValueObjects;

namespace ValueObjects.Entities;

public class User
{
    public EmailAddress EmailAddress { get; private set; }

    public User(EmailAddress emailAddress)
    {
        EmailAddress = emailAddress;
    }
}