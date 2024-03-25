using GenerateUniqueIDsWithNewId.Data.Repositories;
using GenerateUniqueIDsWithNewId.Data.Repositories.Abstractions;

namespace GenerateUniqueIDsWithNewId.Data;

public class UnitOfWork(OrdersDbContext context) : IUnitOfWork
{
    public IOrderRepository OrderRepository { get; } = new OrderRepository(context);

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
     => await context.SaveChangesAsync(cancellationToken);
}
