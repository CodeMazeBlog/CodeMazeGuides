namespace PasswordHasher.Api.Models;

public class RegisteredUser
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string HashedPassword { get; set; }
}