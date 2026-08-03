using Microsoft.AspNetCore.Mvc;
using SagaPattern.Models;
using SagaPattern.Repositories;
using SagaPattern.Saga.Messages;

namespace SagaPattern.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IOrderRepository _repository;
        private readonly IMessageSession _messageSession;

        public OrderController(ILogger<OrderController> logger, 
            IOrderRepository repository, 
            IMessageSession messageSession)
        {
            _logger = logger;
            _repository = repository;
            _messageSession = messageSession;
        }

        [HttpGet(Name = "GetOrder")]
        public async Task<ActionResult<Order>> Get(string orderId)
        {
            Guid orderGuid;
            var validGuid = Guid.TryParse(orderId, out orderGuid);

            if (validGuid) 
            {
                var order = await _repository.GetOrderById(orderGuid);

                return Ok(order);
            }

            return BadRequest();
        }

        [HttpPost(Name = "PostOrder")]
        public async Task<ActionResult> Post([FromBody] OrderRequest request)
        {
            var order = MapToOrder(request);
            await _repository.AddOrder(order);

            var startOrderMessage = new StartOrder
            {
                OrderId = order.OrderId,
            };

            await _messageSession.Send(startOrderMessage);

            return CreatedAtRoute("GetOrder", new { order.OrderId });
        }

        private Order MapToOrder(OrderRequest request)
        {
            return new Order
            {
                OrderId = Guid.NewGuid(),
                Price = request.Price,
                Status = OrderStatus.OrderCreated
            };
        }
    }
}