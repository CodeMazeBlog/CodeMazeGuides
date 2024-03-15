using FixUnableToResolveServiceIssue.Interfaces;
using FixUnableToResolveServiceIssue.Models;

namespace FixUnableToResolveServiceIssue.Services
{
    public class UserService : IUserService
    {
        public User GetUser()
        {
            return new User
            {
                Id = 1,
                FirstName = "Code",
                LastName = "Maze"
            };
        }
    }
}
