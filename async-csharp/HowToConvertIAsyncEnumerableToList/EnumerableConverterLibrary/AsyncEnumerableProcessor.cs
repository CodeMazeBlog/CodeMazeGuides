namespace EnumerableConverterLibrary;

using System.Collections.ObjectModel;

public class AsyncEnumerableProcessor
{
    public async Task ConvertIAsyncEnumerableToListUsingToListAsync()
    {
        IAsyncEnumerable<string> dataStream = GetDataAsync();
        List<string> dataList = await dataStream.ToListAsync();

        foreach (var element in dataList)
        {
            Console.WriteLine(element);
        }
    }

    public async Task ConvertIAsyncEnumerableToListUsingAsyncForeachAsyncExample1()
    {
        IAsyncEnumerable<string> dataStream = GetDataAsync();
        List<string> dataList = new();
        await foreach (string item in dataStream)
        {
            dataList.Add(item);
        }

        foreach (var element in dataList)
        {
            Console.WriteLine(element);
        }
    }

    public async Task ConvertIAsyncEnumerableToListUsingAsyncForeachAsyncExample2()
    {
        IAsyncEnumerable<string> dataStream = GetDataAsync();
        ObservableCollection<string> list = new();
        list.CollectionChanged += (s, e) => Console.WriteLine(list[e.NewStartingIndex]);

        await foreach (var item in dataStream)
        {
            list.Add(item);
        }
    }

    public async IAsyncEnumerable<string> GetDataAsync(int length = 5, int delayInSeconds = 1)
    {
        for (int i = 0; i < length; i++)
        {
            await Task.Delay(delayInSeconds * 1000);
            yield return "string " + i;
        }
    }
}
