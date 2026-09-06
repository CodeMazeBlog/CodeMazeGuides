using Entities.Models;

namespace Contracts
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Account>> AccountsByOwnerAsync(Guid ownerId);
    }
}
