using System.Threading.Channels;

public class Producer
{
    private readonly ChannelWriter<string> _channelWriter;

    private static readonly List<string> _todoItems = new()
    {
        "Make a coffee",
        "Read CodeMaze articles",
        "Go for a run",
        "Eat lunch"
    };

    public Producer(ChannelWriter<string> channelWriter)
    {
        _channelWriter = channelWriter;
    }

    public async Task ProduceWorkAsync()
    {
        //foreach (var todo in _todoItems)
        //{
        //    while (await _channelWriter.WaitToWriteAsync())
        //    {
        //        var todoAdded = _channelWriter.TryWrite(todo);
        //        if (todoAdded)
        //        {
        //            Console.WriteLine($"Added todo: '{todo}' to channel");
        //            break;
        //        }
        //    }
        //    await Task.Delay(500);
        //}
        //_channelWriter.Complete();

        //foreach (var todo in _todoItems)
        //{
        //    if (_channelWriter.TryWrite(todo))
        //    {   
        //        Console.WriteLine($"Added todo: '{todo}' to channel");
        //    }
        //    await Task.Delay(500);
        //}
        //_channelWriter.Complete();
        foreach (var todo in _todoItems)
        {
            await _channelWriter.WriteAsync(todo);
            Console.WriteLine($"Added todo: '{todo}' to channel");
            await Task.Delay(500);
        }
        _channelWriter.TryComplete();
    }
}
