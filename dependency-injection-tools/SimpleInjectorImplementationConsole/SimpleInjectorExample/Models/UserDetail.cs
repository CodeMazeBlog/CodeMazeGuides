namespace SimpleInjectorExample.Models;

public class UserDetail
{
    public User User { get; set; }
    public Address Address { get; set; }
    public UserDetail(User user, Address address)
    {
        User = user;
        Address = address;
    }
}