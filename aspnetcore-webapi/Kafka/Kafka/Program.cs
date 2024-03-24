using Confluent.Kafka;
using YamlDotNet.RepresentationModel;

namespace Kafka;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var producerConfig = new ProducerConfig
        {
            BootstrapServers = $"localhost:{GetKafkaBrokerPort()}",
            ClientId = "order-producer"
        };

        builder.Services.AddSingleton<IProducer<string, string>>(
            new ProducerBuilder<string, string>(producerConfig).Build());

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }

    private static int GetKafkaBrokerPort()
    {
        var solutionDirectory = Directory.GetParent(Environment.CurrentDirectory)?.FullName;

        var input = new StreamReader(Path.Combine(solutionDirectory!, "docker-compose.yml"));
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
