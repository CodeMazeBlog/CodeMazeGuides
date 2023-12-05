using System.Collections.ObjectModel;
using System.Collections.Specialized;
using EnumerableConverterLibrary;

namespace EnumerableConverterLibraryTests;

public class AsyncEnumerableProcessorTests
{
    [Fact]
    public async Task GivenUsingAsyncForeachExample1_WhenDataStreamHasBeenProcessed_ThenElementsCanBeUsed()
    {
        var processor = new AsyncEnumerableProcessor();
        var dataList = new List<string>();

        await foreach (var item in processor.GetDataAsync())
        {
            dataList.Add(item);
        }

        Assert.NotEmpty(dataList);
        Assert.Equal(5, dataList.Count);
    }

    [Fact]
    public async Task GivenUsingAsyncForeachExample2_WhenDataStreamIsBeingProcessed_ThenElementsAreBeingUsed()
    {
        var processor = new AsyncEnumerableProcessor();
        var list = new ObservableCollection<string>();
        var count = 0;

        // Hook up the CollectionChanged event to signal when an item is added
        list.CollectionChanged += (s, e) =>
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                Assert.Equal(count, list.Count); // Verify that each item can be accessed as it is added
            }
        };

        await foreach (var item in processor.GetDataAsync())
        {
            count++;
            list.Add(item);
        }
    }

    [Fact]
    public async Task GivenUsingToListAsync_WhenDataStreamHasBeenProcessed_ThenElementsCanBeUsed()
    {
        var processor = new AsyncEnumerableProcessor();
        var dataList = await processor.GetDataAsync().ToListAsync();

        Assert.NotEmpty(dataList);
        Assert.Equal(5, dataList.Count);
    }
}
