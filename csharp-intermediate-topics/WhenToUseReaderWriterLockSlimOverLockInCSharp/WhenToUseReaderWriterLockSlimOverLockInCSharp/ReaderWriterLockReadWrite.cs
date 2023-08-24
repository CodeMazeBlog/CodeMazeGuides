namespace WhenToUseReaderWriterLockSlimOverLockInCSharp
{
    public class ReaderWriterLockReadWrite : BaseReaderWriter
    {
        private static readonly ReaderWriterLock _readerWriterLock = new();

        public override void AddNumbersToList(object? data)
        {
            var config = (data as ThreadExecutionConfiguration) ?? new ThreadExecutionConfiguration();

            _readerWriterLock.AcquireWriterLock(Timeout.InfiniteTimeSpan);

            try
            {
                for (var cnt = 0; cnt < config.WriterExecutionsCount; cnt++)
                {
                    _listOfNumbers.Add(cnt);
                    Thread.SpinWait(config.WriterExecutionDelay);
                }
            }
            finally
            {
                _readerWriterLock.ReleaseWriterLock();
            }
        }

        public override void ReadListCount(object? data)
        {
            var config = (data as ThreadExecutionConfiguration) ?? new ThreadExecutionConfiguration();

            _readerWriterLock.AcquireReaderLock(Timeout.InfiniteTimeSpan);

            try
            {
                for (var cnt = 0; cnt < config.ReaderExecutionsCount; cnt++)
                {
                    if (_listOfNumbers.Count > 0)
                    {
                        _ = _listOfNumbers[GetNextRandom()];
                    }
                    Thread.SpinWait(config.ReaderExecutionDelay);
                }
            }
            finally
            {
                _readerWriterLock.ReleaseReaderLock();
            }
        }
    }
}