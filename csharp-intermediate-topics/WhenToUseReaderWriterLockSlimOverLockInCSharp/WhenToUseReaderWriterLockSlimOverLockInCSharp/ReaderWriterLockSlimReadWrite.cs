namespace WhenToUseReaderWriterLockSlimOverLockInCSharp
{
    public class ReaderWriterLockSlimReadWrite : BaseReaderWriter
    {
        private static readonly ReaderWriterLockSlim _readerWriterLockSlim = new();

        public override void AddNumbersToList(object? data)
        {
            var config = (data as ThreadExecutionConfiguration) ?? new ThreadExecutionConfiguration();

            _readerWriterLockSlim.EnterWriteLock();

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
                _readerWriterLockSlim.ExitWriteLock();
            }
        }

        public override void ReadListCount(object? data)
        {
            var config = (data as ThreadExecutionConfiguration) ?? new ThreadExecutionConfiguration();

            _readerWriterLockSlim.EnterReadLock();

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
                _readerWriterLockSlim.ExitReadLock();
            }
        }

        public void ReadOrAdd(object? data)
        {
            var config = (data as ThreadExecutionConfiguration) ?? new ThreadExecutionConfiguration();

            var random = GetNextRandom();

            _readerWriterLockSlim.EnterUpgradeableReadLock();

            try
            {
                if (!_listOfNumbers.Contains(random))
                {
                    _readerWriterLockSlim.EnterWriteLock();

                    try
                    {
                        _listOfNumbers.Add(random);
                        Thread.SpinWait(config.WriterExecutionDelay);
                    }
                    finally
                    {
                        _readerWriterLockSlim.ExitWriteLock();
                    }
                }
            }
            finally
            {
                _readerWriterLockSlim.ExitUpgradeableReadLock();
            }
        }
    }
}