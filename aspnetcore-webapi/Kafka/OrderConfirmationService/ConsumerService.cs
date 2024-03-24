using Confluent.Kafka;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace OrderConfirmationService;

public class ConsumerService(IConsumer<string, string> consumer) : IHostedService
{
    private readonly IConsumer<string, string> _consumer = consumer;

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _consumer.Subscribe("order-events");

        Task.Run(() =>
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                var consumeResult = _consumer.Consume(cancellationToken);

                var message = JsonConvert.DeserializeObject<OrderDetails>(consumeResult.Message.Value);

                Console.WriteLine($"Received message: {consumeResult.Message.Value}");
            }
        }, cancellationToken);

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
