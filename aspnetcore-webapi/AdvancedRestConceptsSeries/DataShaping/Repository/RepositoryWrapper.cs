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
    private readonly IDataShaper<Owner> _ownerDataShaper;
    private readonly IDataShaper<Account> _accountDataShaper;
    private IOwnerRepository? _owner;
    private IAccountRepository? _account;

    public RepositoryWrapper(RepositoryContext repositoryContext,
        ISortHelper<Owner> ownerSortHelper,
        ISortHelper<Account> accountSortHelper,
        IDataShaper<Owner> ownerDataShaper,
        IDataShaper<Account> accountDataShaper)
    {
        _repoContext = repositoryContext;
        _ownerSortHelper = ownerSortHelper;
        _accountSortHelper = accountSortHelper;
        _ownerDataShaper = ownerDataShaper;
        _accountDataShaper = accountDataShaper;
    }

    public IOwnerRepository Owner => _owner ??= new OwnerRepository(_repoContext, _ownerSortHelper, _ownerDataShaper);

    public IAccountRepository Account => _account ??= new AccountRepository(_repoContext, _accountSortHelper, _accountDataShaper);

    public void Save() => _repoContext.SaveChanges();
}
