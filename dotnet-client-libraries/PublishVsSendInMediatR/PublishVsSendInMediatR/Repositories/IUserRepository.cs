using PublishVsSendInMediatR.Models;

namespace PublishVsSendInMediatR.Repositories
{
    public interface IUserRepository
    {
        Task<int> CreateUserAsync(User user);
        Task<User> GetAdminUserAsync();
    }
}
