using PasswordHasher.Api.Models;

public interface IUsersRepository
{
    void AddNewUser(RegisteredUser user);
    RegisteredUser? GetHashedPassword(string username);
}