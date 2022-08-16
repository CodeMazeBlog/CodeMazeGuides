using SimpleInjectorExample.Models;

namespace SimpleInjectorExample.Spec;

public interface IUserRepository
{
    User GetUser(int id);
}