using TaskManagementSystem.Domain.Models;

namespace TaskManagementSystem.Application.Interfaces
{
    public interface IUserService
    {
        Task DisableUser(string userId);
        Task<JwtTokenResponse> LoginAsync(LoginModel model);
        Task<JwtTokenResponse> RegisterAsync(RegisterModel model);
    }
}