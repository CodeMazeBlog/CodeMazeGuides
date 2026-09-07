using Contracts;
using Entities;
using Entities.Helpers;
using Entities.Models;

namespace Repository;

public class RepositoryWrapper : IRepositoryWrapper
{
    private readonly RepositoryContext _repoContext;
    private readonly ISortHelper<Owner> _ownerSortHelper;
    private readonly ISortHelper<Account> _accountSortHelper;
    private IOwnerRepository? _owner;
    private IAccountRepository? _account;

    public RepositoryWrapper(RepositoryContext repositoryContext,
        ISortHelper<Owner> ownerSortHelper,
        ISortHelper<Account> accountSortHelper)
    {
        _repoContext = repositoryContext;
        _ownerSortHelper = ownerSortHelper;
        _accountSortHelper = accountSortHelper;
    }

    public IOwnerRepository Owner => _owner ??= new OwnerRepository(_repoContext, _ownerSortHelper);

    public IAccountRepository Account => _account ??= new AccountRepository(_repoContext, _accountSortHelper);

    public void Save() => _repoContext.SaveChanges();
}
