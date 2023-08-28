namespace WhenToUseReaderWriterLockSlimOverLockInCSharp
{
    public class ReaderWriterLockReadWrite : BaseReaderWriter
    {
        private static readonly ReaderWriterLock _readerWriterLock = new();

        public override void AddNumbersToList(int writerExecutionsCount, int writerExecutionDelay)
        {
            _readerWriterLock.AcquireWriterLock(Timeout.InfiniteTimeSpan);

            try
            {
                for (var cnt = 0; cnt < writerExecutionsCount; cnt++)
                {
                    _listOfNumbers.Add(cnt);
                    Thread.SpinWait(writerExecutionDelay);
                }
            }
            finally
            {
                _readerWriterLock.ReleaseWriterLock();
            }
        }

        public override void ReadListCount(int readerExecutionsCount, int readerExecutionDelay)
        {
            _readerWriterLock.AcquireReaderLock(Timeout.InfiniteTimeSpan);

            try
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
            finally
            {
                _readerWriterLock.ReleaseReaderLock();
            }
        }
    }
}