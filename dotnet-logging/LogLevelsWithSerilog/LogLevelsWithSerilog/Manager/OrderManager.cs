using LogLevelsWithSerilog.Models;

namespace LogLevelsWithSerilog.Manager
{
    public class OrderManager : IOrderManager
    {
        private readonly ILogger<OrderManager> _logger;
        public OrderManager(ILogger<OrderManager> logger)
        {
            _logger = logger;
        }

        public OrderModel CreateOrder(int userId, int basketId)
        {
            try
            {
                _logger.LogInformation("Create Order started.");

                if (userId <= 0)
                {
                    _logger.LogWarning("User id must be greater than zero!");
                    throw new Exception("Invalid User Id");
                }

                if (basketId <= 0)
                {
                    _logger.LogWarning("Basket id must be greater than zero!");
                    throw new Exception("Invalid Basket Id");
                }

                var basket = GetBasket(basketId);
                if (basket == null || basket.OrderId.HasValue)
                {
                    _logger.LogCritical("Basket is null or ordered!");
                    throw new Exception("Invalid Basket");
                }

                var order = new OrderModel()
                {
                    UserId = userId,
                    BasketId = basket.BasketId,
                    CreateDate = DateTime.Now,
                    ItemCount = basket.ItemCount,
                    OrderAmount = basket.Amount,
                    Status = 1,
                };

                _logger.LogInformation("Create Order finished.");

                return order;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "CreateOrder failed!");
            }

            return null;
        }

        private BasketModel GetBasket(int basketId)
        {
            var basket = new BasketModel()
            {
                BasketId = basketId,
                OrderId = basketId == 100 ? 1 : null
            };

            return basket;
        }
    }
}
