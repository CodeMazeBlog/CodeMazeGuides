using SwashbuckleVsNSwag.Models.Orders;

namespace SwashbuckleVsNSwag.Repositories.OrderRepository
{
    public interface IOrderRepository
    {
        Order GetById(Guid id);

        void Add(Order order);

        void Remove(Guid id);
    }
}