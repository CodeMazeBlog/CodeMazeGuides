using SimpleInjectorExample.Models;

namespace SimpleInjectorExample;

public class SampleData
{
    public static List<User> Users = new()
    {
        new()
        {
            Id=1,
            FirstName="John",
            LastName="Doe"            
        },
        new()
        {
            Id=2,
            FirstName="Ashley",
            LastName="Walker"
        }
    };
    public static List<Address> Addresses = new()
    {
        new()
        {
            Id = 12,
            UserId = 1,
            BuildingNumber = 22,
            City = "New York",
            Zone = "Zone-1"
        },
        new()
        {
            Id = 122,
            UserId = 2,
            BuildingNumber = 34,
            City = "London",
            Zone = "Zone-2"
        }
    };     
}
