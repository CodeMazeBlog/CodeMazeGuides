using System.Collections.Concurrent;
using UserAPI.Models;

namespace UserAPI.Services;

public interface IUserService
{
    ConcurrentBag<User> GetUsers();
    bool AddUser(User user);
}