using System.Collections.Concurrent;
using ExampleApp.Helpers;

namespace ExampleApp.ConcurrentQueueExamples;

public class UserLineConcurrentQueue
{
    private readonly ConcurrentQueue<User> _users;

    public UserLineConcurrentQueue()
    {
        _users = new();
    }

    public async Task AddUser(int userId)
    {
        var user = await UserProvider.GetUser(userId);
        _users.Enqueue(user);
    }

    public bool TryServeUser(out User? user)
    {
        var isRemoved = _users.TryDequeue(out user);
        if (isRemoved)
        {
            Console.WriteLine($"SERVED: {user}");
        }

        return isRemoved;
    }

    public User? LookWhoIsFirst()
    {
        if (_users.TryPeek(out User? user))
        {
            return user;
        }

        return default;
    }

    public int CountUsersInLine()
    {
        return _users.Count();
    }
}