using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DelegatesDemo.ActionPracticalUsage
{
    public static class ParallelHelpers
    {
        public static async Task ProcessInParallel<TItem>(this ICollection<TItem> collection, int batchSize, Action<TItem> callback, Action<Exception> onException = null)
        {
            for (var skip = 0; skip < collection.Count; skip += batchSize)
            {
                var nextItems = collection.Skip(skip).Take(batchSize).ToArray();

                try
                {
                    var tasks = nextItems.Select(item => Task.Run(() => callback(item)));

                    await Task.WhenAll(tasks).ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    if (onException is null)
                    {
                        throw;
                    }

                    onException(ex);
                }
            }
        }
    }
}
