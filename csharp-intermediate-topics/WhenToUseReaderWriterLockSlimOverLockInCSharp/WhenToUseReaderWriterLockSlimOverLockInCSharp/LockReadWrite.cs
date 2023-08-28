namespace WhenToUseReaderWriterLockSlimOverLockInCSharp
{
    public class LockReadWrite : BaseReaderWriter
    {
        private static readonly object _lockObject = new();

        public override void AddNumbersToList(int writerExecutionsCount, int writerExecutionDelay)
        {
            lock (_lockObject)
            {
                for (var cnt = 0; cnt < writerExecutionsCount; cnt++)
                {
                    _listOfNumbers.Add(cnt);
                    Thread.SpinWait(writerExecutionDelay);
                }
            }
        }

        public override void ReadListCount(int readerExecutionsCount, int readerExecutionDelay)
        {
            lock (_lockObject)
            {
                for (var cnt = 0; cnt < readerExecutionsCount; cnt++)
                {
                    if (_listOfNumbers.Count > 0)
                    {
                        _ = _listOfNumbers[Random.Shared.Next(0, _listOfNumbers.Count)];
                    }
                    Thread.SpinWait(readerExecutionDelay);
                }
            }
        }
    }
}