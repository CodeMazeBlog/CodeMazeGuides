using Microsoft.AspNetCore.Identity;
using PasswordHasher.Api.Models;
using PasswordHasher.Api.Requests;

namespace PasswordHasher.Api.Services;

public class CustomerService(IUsersRepository usersRepository, IPasswordHasher<RegisteredUser> passwordHasher)
    : ICustomerService
{
    public void RegisterUser(RegisterRequest request)
    {
        var hashedPassword = passwordHasher.HashPassword(new RegisteredUser(), request.Password);
        var newUser = new RegisteredUser
        {
            Username = request.Username,
            HashedPassword = hashedPassword
        };
        
        usersRepository.AddNewUser(newUser);
    }

    public LoginResult Login(LoginRequest request)
    {
        var user = usersRepository.GetHashedPassword(request.Username);

        if (user == null)
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