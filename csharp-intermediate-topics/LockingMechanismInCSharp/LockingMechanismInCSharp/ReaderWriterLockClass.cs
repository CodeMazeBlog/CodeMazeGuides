namespace LockingMechanismInCSharp
{
    public static class ReaderWriterLockClass
    {
        private static int _counter;
        private static readonly ReaderWriterLock _readerWriterLock = new();

        public static int Execute()
        {
            var readThread1 = new Thread(Read);
            var readThread2 = new Thread(Read);
            var readThread3 = new Thread(Read);

            readThread1.Start(1);
            readThread2.Start(2);
            readThread3.Start(3);

            var writeThread1 = new Thread(Write);
            var writeThread2 = new Thread(Write);

            writeThread1.Start(1);
            writeThread2.Start(2);

            readThread1.Join();
            readThread2.Join();
            readThread3.Join();

            writeThread1.Join();
            writeThread2.Join();

            return _counter;
        }

        private static void Read(object? id)
        {
            while (_counter < 30)
            {
                _readerWriterLock.AcquireReaderLock(Timeout.Infinite);
                Console.WriteLine($"Reader {id} read counter: {_counter}");
                _readerWriterLock.ReleaseReaderLock();

                Thread.Sleep(100);
            }
        }

        private static void Write(object? id)
        {
            while (_counter < 30)
            {
                _readerWriterLock.AcquireWriterLock(Timeout.Infinite);
                _counter++;
                Console.WriteLine($"Writer {id} increased counter to value {_counter}");
                _readerWriterLock.ReleaseWriterLock();

                Thread.Sleep(100);
            }
        }
    }
}