using Entities.Models;

namespace Entities.Extensions;

public static class OwnerExtensions
{
    public static void Map(this Owner dbOwner, Owner owner)
    {
        dbOwner.Name = owner.Name;
        dbOwner.Address = owner.Address;
        dbOwner.DateOfBirth = owner.DateOfBirth;
    }
}
