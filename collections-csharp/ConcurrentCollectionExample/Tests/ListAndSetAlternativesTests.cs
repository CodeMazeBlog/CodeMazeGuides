using ExampleApp.ListAndSetExamples;

namespace Tests;

public class ListAndSetAlternativesTests
{
    [Fact]
    public void GivenOverlappingIds_WhenAddedFromSeveralThreads_ThenEachIdIsStoredOnce()
    {
        var count = ListAndSetAlternatives.CountUniqueIds(workers: 4, idsPerWorker: 1000);

        Assert.Equal(1000, count);
    }

    [Fact]
    public void GivenSeveralWriters_WhenAppendingToConcurrentQueue_ThenNoItemIsLost()
    {
        var count = ListAndSetAlternatives.AppendToQueue(workers: 4, itemsPerWorker: 1000);

        Assert.Equal(4000, count);
    }

    [Fact]
    public void GivenSeveralWriters_WhenAppendingToLockedList_ThenNoItemIsLost()
    {
        var count = ListAndSetAlternatives.AppendToLockedList(workers: 4, itemsPerWorker: 1000);

        Assert.Equal(4000, count);
    }
}
