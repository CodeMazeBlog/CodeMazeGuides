namespace LockingMechanismInCSharp
{
    public static class SpinLockClass
    {
        private static bool lockAquired;
        private static int _counter;
        private static SpinLock spinLock = new();

        public static int Execute()
        {
            var thread1 = new Thread(IncrementCounter);
            var thread2 = new Thread(IncrementCounter);
            var thread3 = new Thread(IncrementCounter);

            thread1.Start();
            thread2.Start();
            thread3.Start();

            thread1.Join();
            thread2.Join();
            thread3.Join();

            return _counter;
        }

        private static void IncrementCounter()
        {
            try
            {
                if (lockAquired)
                {
                    Thread.Sleep(100);
                }

                spinLock.Enter(ref lockAquired);
                for (int i = 1; i <= 100000; i++)
                {
                    _counter++;
                }
            }
            finally
            {
                if (lockAquired)
                {
                    lockAquired = false;
                    spinLock.Exit();
                }
            }
        }
    }
}