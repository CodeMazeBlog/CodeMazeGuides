namespace AggregateDesign.Domain;

public interface IOrdersRepository
{
    Task<Order?> GetByIdAsync(long id);
    Task<Order> CreateAsync(Order entity);
    Task<Order> UpdateAsync(Order entity);
}
