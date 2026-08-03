using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace CancellationIAsyncEnumerable
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            await IndefinitelyRunningMethod();

            await IndefinitelyRunningMethodCancelled();

            await CompilerGeneratingExample();

            await IndefinitelyRunningWrappedMethodCancelled();
        }

        public static async Task IndefinitelyRunningMethod()
        {
            var indefinitelyRunningRange = GetIndefinitelyRunningRangeAsync();

            await foreach (int index in indefinitelyRunningRange)
            {
                // Do something with the index 
            }
        }

        public static async Task IndefinitelyRunningMethodCancelled()
        {
            var cancellationTokenSource = new CancellationTokenSource(); 
            cancellationTokenSource.CancelAfter(7000);

            var indefinitelyRunningRange = GetIndefinitelyRunningRangeAsync(cancellationTokenSource.Token);

            await foreach (int index in indefinitelyRunningRange)
            {
                // Do something with the index 
            }
        }

        public static async Task IndefinitelyRunningWrappedMethodCancelled()
        {
            var cancellationTokenSource = new CancellationTokenSource();
            cancellationTokenSource.CancelAfter(7000);

            var indefinitelyRunningRange = GetIndefinitelyRunningRangeWrapperAsync();

            await foreach (int index in indefinitelyRunningRange.WithCancellation(cancellationTokenSource.Token))
            {
                // Do something with the index 
            }
        }

        private static IAsyncEnumerable<int> GetIndefinitelyRunningRangeWrapperAsync()
        {
            return GetIndefinitelyRunningRangeAsync();
        }

        private static async IAsyncEnumerable<int> GetIndefinitelyRunningRangeAsync(
            [EnumeratorCancellation] System.Threading.CancellationToken cancellationToken = default)
        {
            int index = 0;
            while (true)
            {
                await Task.Delay(5000, cancellationToken);
                yield return index++;
            }
        }

        private static async Task CompilerGeneratingExample()
        {
            var indefinitelyRunningRange = GetIndefinitelyRunningRangeAsync();

            IAsyncEnumerator<int> enumerator = indefinitelyRunningRange.GetAsyncEnumerator();

            try
            {
                while (await enumerator.MoveNextAsync()) { };
            }
            finally
            {
                if (enumerator != null)
                {
                    await enumerator.DisposeAsync();
                }
            }
        }

        private async Task IndefinitelyRunningTask(CancellationToken cancellationToken)
        {
            while (true)
            {
                await Task.Delay(5000);
                cancellationToken.ThrowIfCancelled();
            }
        }
    }
}
