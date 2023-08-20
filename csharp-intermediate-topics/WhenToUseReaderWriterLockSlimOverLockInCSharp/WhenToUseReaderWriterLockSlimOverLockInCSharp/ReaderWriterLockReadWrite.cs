using System.Diagnostics;

namespace WhenToUseReaderWriterLockSlimOverLockInCSharp
{
    public class ReaderWriterLockReadWrite
    {
        private static readonly Stopwatch stopwatch = new();
        private static readonly ReaderWriterLock readerWriterLock = new();

        public static readonly List<int> ListOfNumbers = new();

        public static long Execute(Configuration config)
        {
            var threads = new List<Thread>();

            for (var cnt = 0; cnt < config.readerThreadsCount; cnt++)
            {
                var readThread = new Thread(ReadListCount);
                threads.Add(readThread);
            }

            for (var cnt = 0; cnt < config.writerThreadsCount; cnt++)
            {
                var writeThread = new Thread(AddNumbersToList);
                threads.Add(writeThread);
            }

            stopwatch.Reset();
            stopwatch.Start();

            foreach (var thread in threads)
            {
                thread.Start(config);
            }

            foreach (var thread in threads)
            {
                thread.Join();
            }

            stopwatch.Stop();

            return stopwatch.ElapsedMilliseconds;
        }

        public static void AddNumbersToList(object? data)
        {
            var config = (data as Configuration) ?? new Configuration();

            readerWriterLock.AcquireWriterLock(Timeout.InfiniteTimeSpan);

            for (var cnt = 0; cnt < config.writerExecutionsCount; cnt++)
            {
                ListOfNumbers.Add(cnt);
                Thread.SpinWait(config.writerExecutionDelay);
            }

            readerWriterLock.ReleaseWriterLock();
        }

        public static void ReadListCount(object? data)
        {
            var config = (data as Configuration) ?? new Configuration();

            readerWriterLock.AcquireReaderLock(Timeout.InfiniteTimeSpan);

            for (var cnt = 0; cnt < config.readerExecutionsCount; cnt++)
            {
                if (ListOfNumbers.Count > 0)
                {
                    var random = new Random().Next(0, ListOfNumbers.Count - 1);
                    _ = ListOfNumbers[random];
                }
                Thread.SpinWait(config.readerExecutionDelay);
            }

            readerWriterLock.ReleaseReaderLock();
        }
    }
}