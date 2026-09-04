using Contracts;
using Entities;
using Entities.Helpers;
using Entities.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Repository;

public class AccountRepository : RepositoryBase<Account>, IAccountRepository
{
    private readonly ISortHelper<Account> _sortHelper;
    private readonly IDataShaper<Account> _dataShaper;

    public AccountRepository(RepositoryContext repositoryContext,
        ISortHelper<Account> sortHelper,
        IDataShaper<Account> dataShaper)
        : base(repositoryContext)
    {
        _sortHelper = sortHelper;
        _dataShaper = dataShaper;
    }

    public async Task<PagedList<ShapedEntity>> GetAccountsByOwner(Guid ownerId, AccountParameters parameters)
    {
        var accounts = FindByCondition(a => a.OwnerId.Equals(ownerId));

        var sortedAccounts = _sortHelper.ApplySort(accounts.OrderBy(a => a.DateCreated), parameters.OrderBy);

        var pagedAccounts = await PagedList<Account>.ToPagedListAsync(sortedAccounts,
            parameters.PageNumber,
            parameters.PageSize);

        var shapedAccounts = _dataShaper.ShapeData(pagedAccounts, parameters.Fields).ToList();

        return new PagedList<ShapedEntity>(shapedAccounts,
            pagedAccounts.TotalCount,
            pagedAccounts.CurrentPage,
            pagedAccounts.PageSize);
    }

    public ShapedEntity GetAccountByOwner(Guid ownerId, Guid id, string? fields) =>
        _dataShaper.ShapeData(GetAccountByOwner(ownerId, id) ?? new Account(), fields);

    public Account? GetAccountByOwner(Guid ownerId, Guid id) =>
        FindByCondition(a => a.OwnerId.Equals(ownerId) && a.Id.Equals(id)).SingleOrDefault();
}
