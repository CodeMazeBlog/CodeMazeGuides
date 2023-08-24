using SwashbuckleVsNSwag.Models.Orders;

namespace SwashbuckleVsNSwag.Repositories.OrderRepository
{
    public class OrderRepository : IOrderRepository
    {
        private Dictionary<Guid, Order> _repository = new Dictionary<Guid, Order>();

        public Order GetById(Guid id)
        {
            return _repository[id];
        }

        public void Add(Order order)
        {
            order.OrderId = Guid.NewGuid();

            _repository[order.OrderId] = order;
        }

        public void Remove(Guid id)
        {
            _repository.Remove(id);
        }
    }
}