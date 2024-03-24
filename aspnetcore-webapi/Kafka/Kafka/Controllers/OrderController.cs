using Confluent.Kafka;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Kafka.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController(IProducer<string, string> producer) : ControllerBase
{
    private readonly IProducer<string, string> _producer = producer;
    private readonly string _topic = "order-events";

    [HttpPost("place-order")]
    public async Task<IActionResult> PlaceOrder(OrderDetails orderDetails)
    {
        try
        {
            var kafkaMessage = new Message<string, string>
            {
                Value = JsonConvert.SerializeObject(orderDetails)
            };

            await _producer.ProduceAsync(_topic, kafkaMessage);

            return Ok("Order placed successfully");
        }
        catch (ProduceException<string, string> ex)
        {
            return BadRequest($"Error publishing message: {ex.Error.Reason}");
        }
    }
}
