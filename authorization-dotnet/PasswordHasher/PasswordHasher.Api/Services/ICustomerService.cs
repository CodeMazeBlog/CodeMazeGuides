using PasswordHasher.Api.Models;
using PasswordHasher.Api.Requests;

namespace PasswordHasher.Api.Services;

public interface ICustomerService
{
    void RegisterUser(RegisterRequest request);
    LoginResult Login(LoginRequest request);
}