using SagaPattern.Models;

namespace SagaPattern.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private Dictionary<Guid, Order> _orders;

        public OrderRepository()
        {
            _orders = new Dictionary<Guid, Order>();
        }

        public Task AddOrder(Order order)
        {
            _orders.Add(order.OrderId, order);

            return Task.CompletedTask;
        }

        public Task<Order> GetOrderById(Guid orderId)
        {
            Order order;

            if (!_orders.TryGetValue(orderId, out order))
            {
                order = new Order();
            }

            return Task.FromResult(order);
        }
    }
}
