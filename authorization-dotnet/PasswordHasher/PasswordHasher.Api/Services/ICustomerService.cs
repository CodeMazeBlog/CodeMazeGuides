using PasswordHasher.Api.Models;
using PasswordHasher.Api.Requests;

namespace PasswordHasher.Api.Services;

public interface ICustomerService
{
    RegisteredUser RegisterUser(RegisterRequest request);
    LoginResult Login(LoginRequest request);
}