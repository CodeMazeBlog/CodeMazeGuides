#nullable disable
using Producer.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Producer.Data;
using Producer.RabbitMQ;

namespace Producer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderDbContext _context;
        private readonly IMessageProducer _messagePublisher;

        public OrdersController(IOrderDbContext context, IMessageProducer messagePublisher)
        {
            _context = context;
            _messagePublisher = messagePublisher;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderDto orderDto)
        {
            Order order = new()
            {
                ProductName = orderDto.ProductName,
                Price = orderDto.Price,
                Quantity = orderDto.Quantity
            };

            _context.Order.Add(order);

            await _context.SaveChangesAsync();

            _messagePublisher.SendMessage(order);

            return Ok(new { id = order.Id });
        }
    }
}
