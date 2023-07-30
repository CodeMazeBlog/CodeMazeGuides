namespace LockingMechanismInCSharp
{
    public class MutexClass
    {
        private static int _counter;
        private static Mutex mutex = new();

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
                if (mutex.WaitOne(1000))
                {
                    for (var cnt = 0; cnt < 100000; cnt++)
                    {
                        _counter++;
                    }
                }
            }
            finally
            {
                mutex.ReleaseMutex();
            }
        }
    }
}