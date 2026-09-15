using Entities.Models;

namespace Contracts
{
    public interface IOwnerRepository
    {
        Task<IEnumerable<Owner>> GetAllOwnersAsync();
        Task<Owner?> GetOwnerByIdAsync(Guid ownerId);
        Task<Owner?> GetOwnerWithDetailsAsync(Guid ownerId);
    }
}
