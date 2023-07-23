namespace LockingMechanismInCSharp
{
    public static class MultithreadWithoutLocking
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

            thread1.Join(); // main thread waiting until thread1 finishes
            thread2.Join(); // main thread waiting until thread2 finishes
            thread3.Join(); // main thread waiting until thread3 finishes

            return _counter;
        }

        private static void IncrementCounter()
        {
            for (var cnt = 0; cnt < 100000; cnt++)
            {
                _counter++;
            }
        }
    }
}