using SimpleInjectorExample.Models;
using SimpleInjectorExample.Spec;

namespace SimpleInjectorExample.Services;

public class AddressRepository : IAddressRepository
{
    public Address GetUserAddress(int userId)
    {
        return SampleData.Addresses.First(address => address.UserId == userId);
    }
}