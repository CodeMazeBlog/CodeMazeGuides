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
        //try
        //{
        //    while (true)
        //    {
        //        var todo = await _channelReader.ReadAsync(); 
        //        Console.WriteLine($"Completing todo: {todo}"); 
        //        await Task.Delay(1500);
        //    }
        //}
        //catch (ChannelClosedException) 
        //{ 
        //    Console.WriteLine("Channel was closed"); 
        //}
        //while (_channelReader.TryRead(out var todo))
        //{
        //    Console.WriteLine($"Completing todo: {todo}");
        //    await Task.Delay(1500);
        //}
        await foreach (var todo in _channelReader.ReadAllAsync())
        {
            Console.WriteLine($"Completing todo: {todo}");
            await Task.Delay(1500);
        }

        Console.WriteLine("All items read");
    }
}