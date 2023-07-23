using System.Threading.Channels;

public class Consumer
{
    private readonly ChannelReader<string> _channelReader;

    public Consumer(ChannelReader<string> channelReader)
    {
        _channelReader = channelReader;
    }

    public async Task ConsumeWorkAsync()
    {
        await foreach (var todo in _channelReader.ReadAllAsync())
        {
            Console.WriteLine($"Completing todo: {todo}");
            await Task.Delay(1500);
        }

        Console.WriteLine("All items read");
    }
}