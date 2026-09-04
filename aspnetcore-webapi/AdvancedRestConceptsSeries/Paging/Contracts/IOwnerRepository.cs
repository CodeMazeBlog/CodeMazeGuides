using Entities.Helpers;
using Entities.Models;
using System;
using System.Threading.Tasks;

namespace Contracts;

public interface IOwnerRepository : IRepositoryBase<Owner>
{
    Task<PagedList<Owner>> GetOwners(OwnerParameters ownerParameters);
    Owner GetOwnerById(Guid ownerId);
    void CreateOwner(Owner owner);
    void UpdateOwner(Owner dbOwner, Owner owner);
    void DeleteOwner(Owner owner);
}
