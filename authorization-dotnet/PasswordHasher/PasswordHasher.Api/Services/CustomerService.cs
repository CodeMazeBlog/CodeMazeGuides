using Microsoft.AspNetCore.Identity;
using PasswordHasher.Api.Models;
using PasswordHasher.Api.Requests;

namespace PasswordHasher.Api.Services;

public class CustomerService
    (IUsersRepository usersRepository, IPasswordHasher<RegisteredUser> passwordHasher) : ICustomerService
{
    public RegisteredUser RegisterUser(RegisterRequest request)
    {
        var hashedPassword = passwordHasher.HashPassword(new RegisteredUser(), request.Password);
        var newUser = new RegisteredUser
        {
            Id = Guid.NewGuid(),
            Username = request.Username,
            HashedPassword = hashedPassword
        };
        
        usersRepository.AddNewUser(newUser);

        return newUser;
    }

    public LoginResult Login(LoginRequest request)
    {
        var user = usersRepository.GetHashedPassword(request.Username);

        if (user is null)
        {
            return LoginResult.Failure;
        }
        
        var verificationResult = passwordHasher.VerifyHashedPassword(user, user.HashedPassword, request.Password);

        switch (verificationResult)
        {
            case PasswordVerificationResult.Success:
            case PasswordVerificationResult.SuccessRehashNeeded:
                return LoginResult.Success;
            default:
                return LoginResult.Failure;
        }
    }
}