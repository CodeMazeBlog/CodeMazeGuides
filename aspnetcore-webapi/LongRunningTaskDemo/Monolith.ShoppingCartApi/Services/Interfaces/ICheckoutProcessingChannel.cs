namespace Monolith.ShoppingCartApi.Services.Interfaces
{
    public interface ICheckoutProcessingChannel
    {
        Task<bool> AddQueueItemAsync(QueueItem item, CancellationToken ct = default);

        IAsyncEnumerable<QueueItem> ReadAllAsync(CancellationToken ct = default);

        bool TryCompleteWriter(Exception? ex = null);
    }
}
