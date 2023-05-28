using PublishVsSendInMediatR.Models;

namespace PublishVsSendInMediatR.Repositories
{
    public class UserRepository : IUserRepository
    {
        public Task<int> CreateUserAsync(User user)
        {
            Random random = new Random();
            int randomNumber = random.Next();

            return Task.FromResult(randomNumber);
        }

        public Task<User> GetAdminUserAsync()
        {
            var user = new User { UserId = 1, Email = "admin@sample.com", UserName = "admin" };

            return Task.FromResult(user);
        }
    }
}
