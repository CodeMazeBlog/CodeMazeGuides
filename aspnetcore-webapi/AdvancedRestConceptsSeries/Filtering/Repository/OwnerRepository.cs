using Contracts;
using Entities;
using Entities.Extensions;
using Entities.Helpers;
using Entities.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Repository;

public class OwnerRepository : RepositoryBase<Owner>, IOwnerRepository
{
    public OwnerRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    {
    }

    public Task<PagedList<Owner>> GetOwners(OwnerParameters ownerParameters)
    {
        var owners = FindAll();

        if (ownerParameters.MinYearOfBirth is { } minYear)
            owners = owners.Where(o => o.DateOfBirth >= new DateTime(minYear, 1, 1));

        if (ownerParameters.MaxYearOfBirth is { } maxYear)
            owners = owners.Where(o => o.DateOfBirth < new DateTime(maxYear + 1, 1, 1));

        var sortedOwners = owners.OrderBy(o => o.Name);

        return PagedList<Owner>.ToPagedListAsync(sortedOwners,
            ownerParameters.PageNumber,
            ownerParameters.PageSize);
    }

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
