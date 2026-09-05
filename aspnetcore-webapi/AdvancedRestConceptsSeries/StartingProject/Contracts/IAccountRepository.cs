using Entities.Models;
using System;
using System.Collections.Generic;

namespace Contracts;

public interface IAccountRepository : IRepositoryBase<Account>
{
    IEnumerable<Account> GetAccountsByOwner(Guid ownerId);
    Account? GetAccountByOwner(Guid ownerId, Guid id);
}
