namespace LockingMechanismInCSharp
{
    public static class DeadLock
    {
        private static int _counter;
        private static readonly object _firstLockObject = new();
        private static readonly object _secondLockObject = new();

        public static int Execute()
        {
            var thread1 = new Thread(IncrementCounter1);
            var thread2 = new Thread(IncrementCounter2);

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();

            return _counter;
        }

        private static void IncrementCounter1()
        {
            lock (_firstLockObject)
            {
                Thread.Sleep(1000);

                lock (_secondLockObject)
                {
                    for (int i = 1; i <= 100000; i++)
                    {
                        _counter++;
                    }
                }
            }
        }

        private static void IncrementCounter2()
        {
            lock (_secondLockObject)
            {
                Thread.Sleep(1000);

                lock (_firstLockObject)
                {
                    for (int i = 1; i <= 100000; i++)
                    {
                        _counter++;
                    }
                }
            }
        }
    }
}