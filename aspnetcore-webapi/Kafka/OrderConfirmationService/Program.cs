using Confluent.Kafka;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OrderConfirmationService;

public class Program
{
    static async Task Main(string[] args)
    {
        var consumerConfig = new ConsumerConfig
        {
            BootstrapServers = "localhost:9092",
            GroupId = "order-consumer",
            AutoOffsetReset = AutoOffsetReset.Earliest
        };

        var builder = Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<IConsumer<string, string>>(
                        new ConsumerBuilder<string, string>(consumerConfig).Build());
                    services.AddHostedService<ConsumerService>();
                });

        var host = builder.Build();

        var kafkaConsumerService = host.Services.GetRequiredService<IHostedService>();

        await kafkaConsumerService.StartAsync(default);

        await Task.Delay(-1);
    }
}