namespace Common.RabbitMq;

public class RabbitMqConfiguration
{
    public required string HostName { get; set; }
    public int Port { get; set; }
    public required string UserName { get; set; }
    public required string Password { get; set; }
    public required string QueueName { get; set; }
}
