using UserAPI.Models;

namespace UserAPI.Services;

public interface IUserService
{
    List<User> GetUsers();
    bool AddUser(User user);
}