using Entities.Models;
using System;
using System.Collections.Generic;

namespace Contracts;

public interface IOwnerRepository : IRepositoryBase<Owner>
{
    IEnumerable<Owner> GetOwners();
    Owner GetOwnerById(Guid ownerId);
    void CreateOwner(Owner owner);
    void UpdateOwner(Owner dbOwner, Owner owner);
    void DeleteOwner(Owner owner);
}
