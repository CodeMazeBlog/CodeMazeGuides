using Entities.Helpers;
using Entities.Models;
using System;
using System.Threading.Tasks;

namespace Contracts;

public interface IAccountRepository : IRepositoryBase<Account>
{
    Task<PagedList<Entity>> GetAccountsByOwner(Guid ownerId, AccountParameters parameters);
    Entity GetAccountByOwner(Guid ownerId, Guid id, string? fields);
    Account? GetAccountByOwner(Guid ownerId, Guid id);
}
