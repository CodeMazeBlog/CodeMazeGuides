using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository;

public class AccountRepository : RepositoryBase<Account>, IAccountRepository
{
    public AccountRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    {
    }

    public IEnumerable<Account> GetAccountsByOwner(Guid ownerId) =>
        FindByCondition(a => a.OwnerId.Equals(ownerId));

    public Account? GetAccountByOwner(Guid ownerId, Guid id) =>
        FindByCondition(a => a.OwnerId.Equals(ownerId) && a.Id.Equals(id)).SingleOrDefault();
}
