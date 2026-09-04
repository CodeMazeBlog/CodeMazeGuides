using Entities.Models;
using System;
using System.Collections.Generic;

namespace Entities.ExtendedModels;

public class OwnerExtended : IEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public string Address { get; set; } = string.Empty;

    public IEnumerable<Account> Accounts { get; set; } = [];

    public OwnerExtended()
    {
    }

    public OwnerExtended(Owner owner)
    {
        Id = owner.Id;
        Name = owner.Name;
        DateOfBirth = owner.DateOfBirth;
        Address = owner.Address;
    }
}
