using Confluent.Kafka;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OrderConfirmationService;
using YamlDotNet.RepresentationModel;

public class Program
{
    static async Task Main(string[] args)
    {
        var consumerConfig = new ConsumerConfig
        {
            BootstrapServers = $"localhost:{GetKafkaBrokerPort()}",
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

    private static int GetKafkaBrokerPort()
    {
        var solutionDirectory = Directory.GetParent(Environment.CurrentDirectory)?.Parent?.Parent?.Parent?.FullName;

        var input = new StreamReader(Path.Combine(solutionDirectory!, @"docker-compose.yml"));
        var yaml = new YamlStream();
        yaml.Load(input);

        var root = (YamlMappingNode)yaml.Documents[0].RootNode;
        var services = (YamlMappingNode)root.Children[new YamlScalarNode("services")];
        var broker = (YamlMappingNode)services.Children[new YamlScalarNode("broker")];

        var ports = (YamlSequenceNode)broker.Children[new YamlScalarNode("ports")];
        var portMapping = (YamlScalarNode)ports.Children.First();

        return int.Parse(portMapping.Value!.Split(":")[0]);
    }
}