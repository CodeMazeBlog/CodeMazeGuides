using SimpleInjectorExample.Models;
using SimpleInjectorExample.Spec;

namespace SimpleInjectorExample.Services;

public class UserService : IUserService
{
    private readonly IAddressRepository _addressRepository;
    private readonly IUserRepository _userRepository;

    public UserService(IAddressRepository addressRepository, IUserRepository userRepository)
    {
        _addressRepository = addressRepository;
        _userRepository = userRepository;
    }

    public UserDetail GetUserDetail(int userId)
    {
        var user = _userRepository.GetUser(userId);
        var address = _addressRepository.GetUserAddress(userId);
        
        return new(user, address);
    }
}