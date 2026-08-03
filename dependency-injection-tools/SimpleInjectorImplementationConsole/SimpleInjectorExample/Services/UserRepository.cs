using SimpleInjectorExample.Models;
using SimpleInjectorExample.Spec;

namespace SimpleInjectorExample.Services;

public class UserRepository : IUserRepository
{
    public User GetUser(int id)
    {
        return SampleData.Users.First(user => user.Id == id);
    }
}
