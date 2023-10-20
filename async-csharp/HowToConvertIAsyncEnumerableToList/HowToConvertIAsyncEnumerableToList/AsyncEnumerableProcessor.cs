namespace HowToConvertIAsyncEnumerableToList;

public class AsyncEnumerableProcessor
{
    public async Task<List<string>> ProcessDataUsingToListAsync()
    {
        IAsyncEnumerable<string> dataStream = GetDataAsync();
        List<string> dataList = await dataStream.ToListAsync();

        // Work with dataList synchronously
        foreach (var item in dataList)
        {
            Console.WriteLine(item);
        }

        return dataList;
    }

    public async Task<List<string>> ProcessDataUsingAsyncForeachAsync()
    {
        List<string> dataList = new List<string>();
        IAsyncEnumerable<string> dataStream = GetDataAsync();
        await foreach (string item in dataStream)
        {
            dataList.Add(item);
        }

        // Work with dataList synchronously
        foreach (var item in dataList)
        {
            Console.WriteLine(item);
        }

        return dataList;
    }

    public async IAsyncEnumerable<string> GetDataAsync()
    {
        await Task.Delay(1000);
        yield return "a";
        yield return "b";
        yield return "c";
    }
}
