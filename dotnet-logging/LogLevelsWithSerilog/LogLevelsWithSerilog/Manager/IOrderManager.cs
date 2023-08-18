using LogLevelsWithSerilog.Models;

namespace LogLevelsWithSerilog.Manager
{
    public interface IOrderManager
    {
        public OrderModel CreateOrder(int userId, int basketId);
    }
}
