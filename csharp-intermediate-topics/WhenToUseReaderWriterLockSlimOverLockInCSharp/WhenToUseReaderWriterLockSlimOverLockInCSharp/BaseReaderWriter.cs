using System.Diagnostics;

namespace WhenToUseReaderWriterLockSlimOverLockInCSharp
{
    public abstract class BaseReaderWriter
    {
        private readonly Stopwatch _stopwatch = new();
        protected readonly List<int> _listOfNumbers = new();

        public List<int> ListOfNumbers
        {
            get { return _listOfNumbers; }
        }

        protected int GetNextRandom()
        {
            var maxNumber = _listOfNumbers.Count > 0 ? _listOfNumbers.Count - 1 : 0;
            return Random.Shared.Next(0, maxNumber);
        }

        public long Execute(ThreadExecutionConfiguration config)
        {
            var threads = new List<Thread>();

            for (var cnt = 0; cnt < config.ReaderThreadsCount; cnt++)
            {
                var readThread = new Thread(ReadListCount);
                threads.Add(readThread);
            }

            for (var cnt = 0; cnt < config.WriterThreadsCount; cnt++)
            {
                var writeThread = new Thread(AddNumbersToList);
                threads.Add(writeThread);
            }

            _stopwatch.Reset();
            _stopwatch.Start();

            foreach (var thread in threads)
            {
                thread.Start(config);
            }

            foreach (var thread in threads)
            {
                thread.Join();
            }
            _stopwatch.Stop();

            return _stopwatch.ElapsedMilliseconds;
        }

        public abstract void AddNumbersToList(object? data);

        public abstract void ReadListCount(object? data);
    }
}