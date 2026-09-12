using Contracts;
using Entities;
using Entities.Extensions;
using Entities.Helpers;
using Entities.Models;
using Repository.Extensions;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Repository;

public class OwnerRepository : RepositoryBase<Owner>, IOwnerRepository
{
    private readonly ISortHelper<Owner> _sortHelper;
    private readonly IDataShaper<Owner> _dataShaper;

    public OwnerRepository(RepositoryContext repositoryContext,
        ISortHelper<Owner> sortHelper,
        IDataShaper<Owner> dataShaper)
        : base(repositoryContext)
    {
        _sortHelper = sortHelper;
        _dataShaper = dataShaper;
    }

    public async Task<PagedList<ShapedEntity>> GetOwners(OwnerParameters ownerParameters)
    {
        var owners = FindAll();

        if (ownerParameters.MinYearOfBirth is { } minYear)
            owners = owners.Where(o => o.DateOfBirth >= new DateTime(minYear, 1, 1));

        if (ownerParameters.MaxYearOfBirth is { } maxYear)
            owners = owners.Where(o => o.DateOfBirth < new DateTime(maxYear + 1, 1, 1));

        owners = owners.Search(ownerParameters.SearchTerm);

        var sortedOwners = _sortHelper.ApplySort(owners.OrderBy(o => o.Name), ownerParameters.OrderBy);

        var pagedOwners = await PagedList<Owner>.ToPagedListAsync(sortedOwners,
            ownerParameters.PageNumber,
            ownerParameters.PageSize);

        var shapedOwners = _dataShaper.ShapeData(pagedOwners, ownerParameters.Fields).ToList();

        return new PagedList<ShapedEntity>(shapedOwners,
            pagedOwners.TotalCount,
            pagedOwners.CurrentPage,
            pagedOwners.PageSize);
    }

    public ShapedEntity GetOwnerById(Guid ownerId, string? fields) =>
        _dataShaper.ShapeData(GetOwnerById(ownerId), fields);

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
