using Microsoft.AspNetCore.Mvc;
using SwashbuckleVsNSwag.Models.Orders;
using SwashbuckleVsNSwag.Repositories.OrderRepository;

namespace SwashbuckleVsNSwag.Swashbuckle.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IOrderRepository _orders;

        public OrderController(ILogger<OrderController> logger, IOrderRepository orders)
        {
            _logger = logger;
            _orders = orders;
        }

        [HttpGet(Name = "GetOrderById")]
        public ActionResult<Order> Get(Guid orderId)
        {
            return _orders.GetById(orderId);
        }

        [HttpPost(Name = "PostOrder")]
        public ActionResult<Order> Post(Order order)
        {
            _orders.Add(order);

            return order;
        }
    }
}