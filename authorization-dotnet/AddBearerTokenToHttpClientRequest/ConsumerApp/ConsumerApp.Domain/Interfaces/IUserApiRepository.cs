using ConsumerApp.Domain.Model;

namespace ConsumerApp.Domain.Interfaces
{
    public interface IUserApiRepository
    {
        Task PostUsersAsync(UserModel userModel, string token);
        Task<IEnumerable<UserModel>> GetUsersAsync();
        Task<UserModel> GetUsersAsync(int userId);
    }
}
