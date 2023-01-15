using AsynchronousProgrammingPatterns.Services;
using AsynchronousProgrammingPatterns.Services.Models;

namespace AsynchronousProgrammingPatterns.Providers;

public class TapUserProvider
{
    private readonly UserService _userService;

    public TapUserProvider()
    {
        _userService = new UserService();
    }

    public User GetUser(int userId) => _userService.GetUser(userId);

    public Task<User> GetUserAsync(int userId)
    {
        return Task.Run(() => GetUser(userId));
    }
}
