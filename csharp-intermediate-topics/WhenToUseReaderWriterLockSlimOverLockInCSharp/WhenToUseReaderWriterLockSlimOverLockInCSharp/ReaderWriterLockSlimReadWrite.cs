namespace WhenToUseReaderWriterLockSlimOverLockInCSharp
{
    public class ReaderWriterLockSlimReadWrite : BaseReaderWriter
    {
        private static readonly ReaderWriterLockSlim _readerWriterLockSlim = new();

        public override void AddNumbersToList(int writerExecutionsCount, int writerExecutionDelay)
        {
            _readerWriterLockSlim.EnterWriteLock();

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
                _readerWriterLockSlim.ExitWriteLock();
            }
        }

        public override void ReadListCount(int readerExecutionsCount, int readerExecutionDelay)
        {
            _readerWriterLockSlim.EnterReadLock();

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
                _readerWriterLockSlim.ExitReadLock();
            }
        }

        public void ReadOrAdd(int writerExecutionDelay)
        {
            var random = Random.Shared.Next(0, _listOfNumbers.Count);

            _readerWriterLockSlim.EnterUpgradeableReadLock();

            try
            {
                if (!_listOfNumbers.Contains(random))
                {
                    _readerWriterLockSlim.EnterWriteLock();

                    try
                    {
                        _listOfNumbers.Add(random);
                        Thread.SpinWait(writerExecutionDelay);
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