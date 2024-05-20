using PasswordHasher.Api.Models;

namespace PasswordHasher.Api.Repositories;

public class UsersRepository : IUsersRepository
{
    private Dictionary<string, RegisteredUser> _users = new();

    public void AddNewUser(RegisteredUser user) => 
        _users.Add(user.Username, user);

    public RegisteredUser? GetHashedPassword(string username) => 
        _users.TryGetValue(username, out var user)
            ? user
            : null;
}