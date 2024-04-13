using GenerateUniqueIDsWithNewId.Data.Models;

namespace GenerateUniqueIDsWithNewId.Data.Repositories.Abstractions;

public interface IOrderRepository
{
    Task<IEnumerable<Order>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Order?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    void Insert(Order order);
    void Remove(Order order);
}
