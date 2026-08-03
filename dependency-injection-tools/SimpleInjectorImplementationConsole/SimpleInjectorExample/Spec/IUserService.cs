using SimpleInjectorExample.Models;

namespace SimpleInjectorExample.Spec;

public interface IUserService
{
    UserDetail GetUserDetail(int userId);
}