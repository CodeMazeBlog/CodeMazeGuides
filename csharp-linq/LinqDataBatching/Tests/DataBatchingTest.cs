using App;

namespace Tests;

public class DataBatchingTest
{
    private readonly List<int> _data = Enumerable.Range(0, 10000).ToList();

    [Fact]
    public void WhenBatchingByTraditional_ThenReturnsCorrectNumberOfBatches()
    {
        var batches = _data.BatchByTraditional(100);
        
        Assert.Equal(100, batches.Count);
    }

    [Fact]
    public void WhenBatchingByLinq_ThenReturnsCorrectNumberOfBatches()
    {
        var batches = _data.BatchByLinq(100);
        
        Assert.Equal(100, batches.Count);
    }

    [Fact]
    public void WhenBatchingByChunk_ThenReturnsCorrectNumberOfBatches()
    {
        var batches = _data.BatchByChunk(100).ToList();
        
        Assert.Equal(100, batches.Count);
    }
}