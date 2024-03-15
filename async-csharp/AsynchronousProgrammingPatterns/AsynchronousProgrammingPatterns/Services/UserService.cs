using AsynchronousProgrammingPatterns.Services.Models;

namespace AsynchronousProgrammingPatterns.Services;

public class UserService
{
    private readonly List<User> _users = new()
    {
        new User { Id = 100, Name="Adam"},
        new User { Id = 101, Name="Eve"}
    };

    public User GetUser(int userId)
    {
        // Long-running operation

        return _users.FirstOrDefault(x => x.Id == userId);
    }
}
