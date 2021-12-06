namespace ActionAndFunc
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CallWebService(DummyVoidService);

            int result = CallWebService(DummyService);
        }
        /// <summary>
        /// We can pass every method which do not return any value and do not have any input parameter
        /// If we need to pass parametric method, we need to use the generic form of Action delegate
        /// </summary>
        public static void CallWebService(Action work)
        {
            int retryCount = 3;
            do
            {
                try
                {
                    work();
                    return;
                }
                catch
                {
                    if (retryCount <= 0)
                        throw;
                    else
                    {
                        Thread.Sleep(1000);
                    }
                }

            } while (retryCount-- > 0);
        }

        /// <summary>
        /// We can pass every method which have int as return type and do not have any input parameter
        /// If we need to use parametric methods, then we need to provide the parameters input type
        /// </summary>
        public static int CallWebService(Func<int> work)
        {
            int retryCount = 3;
            do
            {
                try
                {
                    return work();
                }
                catch
                {
                    if (retryCount <= 0)
                        throw;
                    else
                    {
                        Thread.Sleep(1000);
                    }
                }

            } while (retryCount-- > 0);
            return -1;
        }
        static int DummyService() { return 10; }
        static void DummyVoidService() { }
    }
}
