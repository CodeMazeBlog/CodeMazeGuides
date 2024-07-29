using UserAPI.Models;

namespace UserAPI.Services;

public class UserService : IUserService
{
    static readonly List<User> users = [
        new User(1, "John Doe", "John.Doe@gmail.com"),
        new User(2, "Jane Doe", "Jane.Doe@gmail.com")];

    public List<User> GetUsers()
    {
        return users;
    }
    public bool AddUser(User user)
    {
        users.Add(user);
        return true;
    }
}