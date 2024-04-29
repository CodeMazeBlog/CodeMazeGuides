namespace PasswordHasher.Api.Models;

public class RegisteredUser
{
    public string Username { get; set; }
    public string HashedPassword { get; set; }
}