using Entities.Helpers;
using Entities.Models;
using System;
using System.Threading.Tasks;

namespace Contracts;

public interface IAccountRepository : IRepositoryBase<Account>
{
    Task<PagedList<Account>> GetAccountsByOwner(Guid ownerId, AccountParameters parameters);
    Account? GetAccountByOwner(Guid ownerId, Guid id);
}
