using Contracts;
using Entities;

namespace Repository
{
    public class RepositoryWrapper(RepositoryContext repositoryContext) : IRepositoryWrapper
    {
        private readonly RepositoryContext _repoContext = repositoryContext;
        private IOwnerRepository? _owner;
        private IAccountRepository? _account;

        public IOwnerRepository Owner => _owner ??= new OwnerRepository(_repoContext);

        public IAccountRepository Account => _account ??= new AccountRepository(_repoContext);

        public async Task SaveAsync() => await _repoContext.SaveChangesAsync();
    }
}
