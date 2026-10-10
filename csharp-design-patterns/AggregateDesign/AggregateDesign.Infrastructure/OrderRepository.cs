using AggregateDesign.Domain;
using Microsoft.EntityFrameworkCore;

namespace AggregateDesign.Infrastructure;

public sealed class OrderRepository(OrdersDbContext dbContext) : IOrderRepository
{
    public Task<Order?> GetByIdAsync(long orderId, CancellationToken cancellationToken = default) =>
        dbContext.Orders.FirstOrDefaultAsync(o => o.Id == orderId, cancellationToken);

    public void Add(Order order) => dbContext.Orders.Add(order);

    public Task SaveChangesAsync(CancellationToken cancellationToken = default) =>
        dbContext.SaveChangesAsync(cancellationToken);
}
