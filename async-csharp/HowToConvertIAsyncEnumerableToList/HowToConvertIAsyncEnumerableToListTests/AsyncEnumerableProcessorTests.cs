using HowToConvertIAsyncEnumerableToList;

namespace HowToConvertIAsyncEnumerableToListTests;

public class AsyncEnumerableProcessorTests
{
    private readonly List<string> dataList = new() { "a", "b", "c" };
    
    [Fact]
    public async Task WhenUsingToListAsync_ThenReturnList()
    {
        var processor = new AsyncEnumerableProcessor();
        
        var result = await processor.ProcessDataUsingToListAsync();
        
        Assert.Equal(dataList, result);
    }
    
    [Fact]
    public async Task WhenUsingAsyncForeachAsync_ThenReturnList()
    {
        var processor = new AsyncEnumerableProcessor();
        
        var result = await processor.ProcessDataUsingAsyncForeachAsync();
        
        Assert.Equal(dataList, result);
    }
}
