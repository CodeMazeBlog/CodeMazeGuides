using ExceptionHandlingInCSharp.Exceptions;
using ExceptionHandlingInCSharp.Models;

namespace ExceptionHandlingInCSharp.Services;

public class UserService
{
    private readonly List<User> _users = new()
    {
        new User { Id = 1, Name = "Code Maze"},
        new User { Id = 2, Name = "John Doe"}
    };

    public User GetById(int id)
    {
        ValidateID(id);

        var user = _users.First(x => x.Id == id);

        return user;
    }

    private static void ValidateID(int id)
    {
        if (id <= 0 || id >= 1000)
            throw new InvalidUserIdException();
    }

    public void Clear() => _users.Clear();
}
