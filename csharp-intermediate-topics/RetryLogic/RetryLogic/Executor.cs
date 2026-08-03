using RetryLogic.Exceptions;

namespace RetryLogic
{
    public static class Executor
    {
        public static void Execute(Action action, int numberOfRetries)
        {
            var tries = 0;

            while (tries <= numberOfRetries)
            {
                try
                {
                    action();
                    return;
                }
                catch
                {
                    tries++;
                }
            }

            throw new RetryException($"Error after {tries} tries");
        }

        public static TResult? Execute<TResult>(Func<TResult> func, int numberOfRetries)
        {
            var tries = 0;

            while (tries <= numberOfRetries)
            {
                try
                {
                    return func();
                }
                catch
                {
                    tries++;
                }
            }

            throw new RetryException($"Error after {tries} tries");
        }
    }
}
