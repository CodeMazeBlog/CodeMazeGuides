using RetryLogic.Exceptions;

namespace RetryLogic
{
    public static class Executor
    {
        public static void Execute(Action action, int numberOfRetries)
        {
            int tries = 0;

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

            throw new RetryException($"Error after {numberOfRetries + 1 } tries");
        }

        public static TResult? Execute<TResult>(Func<TResult> func, int numberOfRetries)
        {
            int i = 0;
            while (i <= numberOfRetries)
            {
                try
                {
                    return func();
                }
                catch
                {
                    i++;
                }
            }

            throw new RetryException($"Error after {numberOfRetries + 1 } tries");
        }
    }
}
