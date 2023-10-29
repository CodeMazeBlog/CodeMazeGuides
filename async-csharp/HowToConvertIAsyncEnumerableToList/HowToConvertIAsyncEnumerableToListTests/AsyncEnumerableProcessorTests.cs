using HowToConvertIAsyncEnumerableToList;

namespace HowToConvertIAsyncEnumerableToListTests;

public class AsyncEnumerableProcessorTests
{
    private readonly List<string> dataList = new() { "item0", "item1", "item2" };

    [Fact]
    public async Task WhenUsingToListAsync_ThenReturnList()
    {
        var processor = new AsyncEnumerableProcessor();

        List<string> result = await processor.GetDataAsync().ToListAsync();

        Assert.Equal(dataList, result);
    }

    [Fact]
    public async Task WhenUsingAsyncForeachAsync_ThenReturnList()
    {
        var processor = new AsyncEnumerableProcessor();
        List<string> result = new();

        await foreach (string item in processor.GetDataAsync())
        {
            result.Add(item);
        }

        Assert.Equal(dataList, result);
    }
}
