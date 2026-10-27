using Microsoft.AspNetCore.Identity;

namespace WebApiBestPractices.Api.Security;

public class AppUser
{
    public required string UserName { get; init; }
}

public class AccountService(IPasswordHasher<AppUser> passwordHasher)
{
    public string HashPassword(AppUser user, string password) =>
        passwordHasher.HashPassword(user, password);

    public bool VerifyPassword(AppUser user, string hashedPassword, string password) =>
        passwordHasher.VerifyHashedPassword(user, hashedPassword, password)
            != PasswordVerificationResult.Failed;
}
