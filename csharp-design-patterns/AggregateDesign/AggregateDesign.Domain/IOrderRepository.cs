namespace AggregateDesign.Domain;

public interface IOrderRepository
{
    Task<Order?> GetByIdAsync(long orderId, CancellationToken cancellationToken = default);

    void Add(Order order);

    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}
