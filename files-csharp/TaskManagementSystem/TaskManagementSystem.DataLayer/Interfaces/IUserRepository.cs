using System.Security.Claims;
using TaskManagementSystem.DataLayer.Dtos;
using TaskManagementSystem.Domain.Models;

namespace TaskManagementSystem.DataLayer.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> ExistsAsync(string userId);
        Task<List<Claim>?> LoginAsync(LoginModel model);
        Task<RegisterResultDto> RegisterAsync(RegisterModel model);
        Task<bool> DisableUser(string userId);
        Task SaveChangesAsync();
    }
}