using Contracts;
using Entities;

namespace Repository;

public class RepositoryWrapper : IRepositoryWrapper
{
    private readonly RepositoryContext _repoContext;
    private IOwnerRepository? _owner;
    private IAccountRepository? _account;

    public RepositoryWrapper(RepositoryContext repositoryContext)
    {
        _repoContext = repositoryContext;
    }

    public IOwnerRepository Owner => _owner ??= new OwnerRepository(_repoContext);

    public IAccountRepository Account => _account ??= new AccountRepository(_repoContext);

    public void Save() => _repoContext.SaveChanges();
}
