namespace Shared;
public class UserCreatedEvent
{
    public UserCreatedEvent(string userName)
    {
        UserName = userName;
    }

    public string UserName { get; }
}
