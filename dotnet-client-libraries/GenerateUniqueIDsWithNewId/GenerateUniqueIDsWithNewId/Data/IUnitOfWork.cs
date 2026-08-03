using GenerateUniqueIDsWithNewId.Data.Repositories.Abstractions;

namespace GenerateUniqueIDsWithNewId.Data;

public interface IUnitOfWork
{
    IOrderRepository OrderRepository { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
