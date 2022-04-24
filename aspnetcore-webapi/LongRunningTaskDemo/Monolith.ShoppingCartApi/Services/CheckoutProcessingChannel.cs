using System.Threading.Channels;
using Monolith.ShoppingCartApi.Services.Interfaces;

namespace Monolith.ShoppingCartApi.Services
{
    public class CheckoutProcessingChannel : ICheckoutProcessingChannel
    {
        private const int MaxMessagesInChannel = 100;
        private readonly Channel<QueueItem> _channel;
        private readonly ILogger<CheckoutProcessingChannel> _logger;

        public CheckoutProcessingChannel(ILogger<CheckoutProcessingChannel> logger)
        {
            _logger = logger;

            var options = new BoundedChannelOptions(MaxMessagesInChannel)
            {
                SingleWriter = false,
                SingleReader = true
            };

            _channel = Channel.CreateBounded<QueueItem>(options);            
        }

        public async Task<bool> AddQueueItemAsync(QueueItem item, CancellationToken ct = default)
        {
            while (await _channel.Writer.WaitToWriteAsync(ct) && !ct.IsCancellationRequested)
            {
                if (_channel.Writer.TryWrite(item))
                {
                    _logger.LogInformation($"{item.OrderId} added to channel.");
                    return true;
                }
            }

            return false;
        }

        public IAsyncEnumerable<QueueItem> ReadAllAsync(CancellationToken ct = default) 
            => _channel.Reader.ReadAllAsync(ct);

        public bool TryCompleteWriter(Exception? ex = null) 
            => _channel.Writer.TryComplete(ex);
    }
}