using System.Diagnostics;

namespace WhenToUseReaderWriterLockSlimOverLockInCSharp
{
    public class ReaderWriterLockSlimReadWrite
    {
        private static readonly Stopwatch stopwatch = new();
        private static readonly ReaderWriterLockSlim readerWriterLockSlim = new();

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

            readerWriterLockSlim.EnterWriteLock();

            for (var cnt = 0; cnt < config.writerExecutionsCount; cnt++)
            {
                ListOfNumbers.Add(cnt);
                Thread.SpinWait(config.writerExecutionDelay);
            }

            readerWriterLockSlim.ExitWriteLock();
        }

        public static void ReadListCount(object? data)
        {
            var config = (data as Configuration) ?? new Configuration();

            readerWriterLockSlim.EnterReadLock();

            for (var cnt = 0; cnt < config.readerExecutionsCount; cnt++)
            {
                if (ListOfNumbers.Count > 0)
                {
                    var random = new Random().Next(0, ListOfNumbers.Count - 1);
                    _ = ListOfNumbers[random];
                }
                Thread.SpinWait(config.readerExecutionDelay);
            }

            readerWriterLockSlim.ExitReadLock();
        }

        public static void ReadOrAdd(object? data)
        {
            var config = (data as Configuration) ?? new Configuration();

            readerWriterLockSlim.EnterUpgradeableReadLock();

            var maxNumber = ListOfNumbers.Count > 0 ? ListOfNumbers.Count - 1 : 1;
            var random = new Random().Next(0, maxNumber);

            if (!ListOfNumbers.Any(x => x == random))
            {
                readerWriterLockSlim.EnterWriteLock();

                ListOfNumbers.Add(random);
                Thread.SpinWait(config.writerExecutionDelay);

                readerWriterLockSlim.ExitWriteLock();
            }

            readerWriterLockSlim.ExitUpgradeableReadLock();
        }
    }
}