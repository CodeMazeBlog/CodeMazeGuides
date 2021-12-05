using System;

namespace CancellationIAsyncEnumerable
{
    public class CancellationToken
    {
        public bool IsCancelled { get; set; }

        public void Cancel()
        {
            IsCancelled = true;
        }

        public void ThrowIfCancelled()
        {
            if (IsCancelled)
            {
                throw new OperationCanceledException();
            }
        }
    }
}
