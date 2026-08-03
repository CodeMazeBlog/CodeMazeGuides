using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository 
    { 
        public AccountRepository(RepositoryContext repositoryContext) 
            : base(repositoryContext) 
        { 
        }

        public IEnumerable<Account> AccountsByOwner(Guid ownerId) =>
            FindByCondition(a => a.OwnerId.Equals(ownerId)).ToList();
    }
}
