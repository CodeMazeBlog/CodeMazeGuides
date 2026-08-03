using ConsumerApp.Domain.Model;

namespace ConsumerApp.Domain.Interfaces
{
    public interface IUserApiRepository
    {
        Task CreateUserAsync(UserModel userModel, string token);
        Task<IEnumerable<UserModel>> GetUsersAsync();
        Task<UserModel> GetUserAsync(int userId);
    }
}
