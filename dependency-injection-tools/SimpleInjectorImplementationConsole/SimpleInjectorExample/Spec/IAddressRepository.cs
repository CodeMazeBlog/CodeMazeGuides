using SimpleInjectorExample.Models;

namespace SimpleInjectorExample.Spec;

public interface IAddressRepository
{
    Address GetUserAddress(int userId);
}
