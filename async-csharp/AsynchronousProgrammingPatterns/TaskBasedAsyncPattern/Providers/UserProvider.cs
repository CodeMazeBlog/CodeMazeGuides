using Services;
using Services.Models;

namespace TaskBasedAsyncPattern.Providers;

public class UserProvider
{
    private readonly UserService _userService;

    public UserProvider()
    {
        _userService = new UserService();
    }

    public User GetUser(int userId) => _userService.GetUser(userId);

    public Task<User> GetUserAsync(int userId)
    {
        return Task.Run(() => GetUser(userId));
    }
}
