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

    public AccountRepository(RepositoryContext repositoryContext,
        ISortHelper<Account> sortHelper)
        : base(repositoryContext)
    {
        _sortHelper = sortHelper;
    }

    public Task<PagedList<Account>> GetAccountsByOwner(Guid ownerId, AccountParameters parameters)
    {
        var accounts = FindByCondition(a => a.OwnerId.Equals(ownerId));

        var sortedAccounts = _sortHelper.ApplySort(accounts.OrderBy(a => a.DateCreated), parameters.OrderBy);

        return PagedList<Account>.ToPagedListAsync(sortedAccounts,
            parameters.PageNumber,
            parameters.PageSize);
    }

    public Account? GetAccountByOwner(Guid ownerId, Guid id) =>
        FindByCondition(a => a.OwnerId.Equals(ownerId) && a.Id.Equals(id)).SingleOrDefault();
}
