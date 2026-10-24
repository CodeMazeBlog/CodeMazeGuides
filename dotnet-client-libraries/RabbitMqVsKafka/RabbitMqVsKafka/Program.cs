using RabbitMqVsKafka;

const string rabbitMq = "amqp://guest:guest@localhost:5672";
const string kafka = "localhost:9092";

switch (args.FirstOrDefault())
{
    case "rabbit":
        await new RabbitQueueDemo(rabbitMq).RunAsync();
        break;
    case "kafka":
        await new KafkaDemo(kafka).RunAsync();
        break;
    case "stream":
        await new RabbitStreamDemo(rabbitMq).RunAsync();
        break;
    default:
        Console.WriteLine("Usage: dotnet run -- rabbit | kafka | stream");
        break;
}
