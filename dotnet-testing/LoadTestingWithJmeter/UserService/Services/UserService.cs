using System.Collections.Concurrent;
using UserAPI.Models;

namespace UserAPI.Services;

public class UserService : IUserService
{
    static readonly ConcurrentBag<User> users = [
        new User(1, "John Doe", "John.Doe@gmail.com"),
        new User(2, "Jane Doe", "Jane.Doe@gmail.com")];

    public ConcurrentBag<User> GetUsers()
    {
        return users;
    }
    public bool AddUser(User user)
    {
        users.Add(user);

        return true;
    }
}