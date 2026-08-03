using Confluent.Kafka;
using Shared;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Kafka.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController(IProducer<string, string> producer) : ControllerBase
{
    private readonly IProducer<string, string> _producer = producer;
    private const string Topic = "order-events";

    [HttpPost("place-order")]
    public async Task<IActionResult> PlaceOrder(OrderDetails orderDetails)
    {
        try
        {
            var kafkaMessage = new Message<string, string>
            {
                Value = JsonConvert.SerializeObject(orderDetails)
            };

            await _producer.ProduceAsync(Topic, kafkaMessage);

            return Ok("Order placed successfully");
        }
        catch (ProduceException<string, string> ex)
        {
            return BadRequest($"Error publishing message: {ex.Error.Reason}");
        }
    }
}
