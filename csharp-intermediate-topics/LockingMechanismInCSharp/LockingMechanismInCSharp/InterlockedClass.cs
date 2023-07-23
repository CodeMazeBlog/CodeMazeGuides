namespace LockingMechanismInCSharp
{
    public static class InterlockedClass
    {
        private static int _counter = 0;

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
            for (var cnt = 0; cnt < 100000; cnt++)
            {
                Interlocked.Increment(ref _counter);
            }
        }
    }
}