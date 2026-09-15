using Contracts;
using Entities;
using Entities.Extensions;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository;

public class OwnerRepository : RepositoryBase<Owner>, IOwnerRepository
{
    public OwnerRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    {
    }

    public IEnumerable<Owner> GetOwners() =>
        FindAll()
            .OrderBy(o => o.Name);

    public Owner GetOwnerById(Guid ownerId) =>
        FindByCondition(owner => owner.Id.Equals(ownerId)).SingleOrDefault() ?? new Owner();

    public void CreateOwner(Owner owner) => Create(owner);

    public void UpdateOwner(Owner dbOwner, Owner owner)
    {
        dbOwner.Map(owner);
        Update(dbOwner);
    }

    public void DeleteOwner(Owner owner) => Delete(owner);
}
