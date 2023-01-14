using Services.Models;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class UserService
    {
        private readonly List<User> _users = new List<User>
        {
            new User { Id = 100, Name="Adam"},
            new User { Id = 101, Name="Eve"}
        };

        public User GetUser(int userId)
        {
            // Long-running operation

            return _users.FirstOrDefault(x => x.Id == userId);
        }
    }
}
