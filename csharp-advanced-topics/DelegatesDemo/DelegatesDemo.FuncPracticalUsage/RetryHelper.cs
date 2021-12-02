using System;
using System.Threading;

namespace DelegatesDemo.FuncPracticalUsage
{
    public static class RetryHelper
    {
        public static T RetryOnException<T>(Func<T> action, int retryCount, TimeSpan retryDelay)
        {
            var result = default(T);

            do
            {
                try
                {
                    result = action();
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine($"Retry initiated (retry count: {retryCount})");
                    if (retryCount == 0)
                    {
                        throw;
                    }
                }

                Thread.Sleep(retryDelay);
            } while (retryCount-- > 0);

            return result;
        }
    }
}
