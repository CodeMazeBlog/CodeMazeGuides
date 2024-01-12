using App;

namespace Tests;

public class DataBatchingTest
{
    private readonly List<int> _data = Enumerable.Range(0, 10000).ToList();

    [Fact]
    public void When_BatchingByTraditional_Then_ReturnsCorrectNumberOfBatches()
    {
        var batches = _data.BatchByTraditional(100);
        
        Assert.Equal(100, batches.Count);
    }

    [Fact]
    public void When_BatchingByLinq_Then_ReturnsCorrectNumberOfBatches()
    {
        var batches = _data.BatchByLinq(100);
        
        Assert.Equal(100, batches.Count);
    }

    [Fact]
    public void When_BatchingByChunk_Then_ReturnsCorrectNumberOfBatches()
    {
        var batches = _data.BatchByChunk(100).ToList();
        
        Assert.Equal(100, batches.Count);
    }
}