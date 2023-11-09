using ExampleApp.ConcurrentBagExamples;

namespace Tests;

public class StorageConcurrentBagTests
{
    [Fact]
    public async Task GivenFileNames_WhenAddFileIsInvokedConcurrently_ThenFilesAreAdded()
    {
        var storage = new StorageConcurrentBag();
        var task1 = Task.Run(() => storage.AddNew("sample.txt"));
        var task2 = Task.Run(() => storage.AddNew("awsome.png"));
        var task3 = Task.Run(() => storage.AddNew("sample.pdf"));

        await Task.WhenAll(task1, task2, task3);

        Assert.Equal(3, storage.CountFiles());
    }

    [Fact]
    public void GivenFileName_WhenTryRemoveIsInvoked_ThenFileIsRemovedAndReturnsTrue()
    {
        var fileName = "awsome.png";
        var storage = new StorageConcurrentBag();
        storage.AddNew(fileName);
        var result = storage.TryRemove(out string? removedFile);

        Assert.True(result);
        Assert.Equal(fileName, removedFile);
    }

    [Fact]
    public void GivenFileName_WhenTryGetIsInvoked_ThenFileIsRetrivedAndReturnsTrue()
    {
        var fileName = "awsome.png";
        var storage = new StorageConcurrentBag();
        storage.AddNew(fileName);
        var result = storage.TryGet(out string? retrievedFile);

        Assert.True(result);
        Assert.Equal(1, storage.CountFiles());
        Assert.Equal(fileName, retrievedFile);
    }
}