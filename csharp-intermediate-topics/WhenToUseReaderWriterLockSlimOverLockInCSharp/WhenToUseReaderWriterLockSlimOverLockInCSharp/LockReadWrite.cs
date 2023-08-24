namespace WhenToUseReaderWriterLockSlimOverLockInCSharp
{
    public class LockReadWrite : BaseReaderWriter
    {
        private static readonly object _lockObject = new();

        public override void AddNumbersToList(object? data)
        {
            var config = (data as ThreadExecutionConfiguration) ?? new ThreadExecutionConfiguration();

            lock (_lockObject)
            {
                for (var cnt = 0; cnt < config.WriterExecutionsCount; cnt++)
                {
                    _listOfNumbers.Add(cnt);
                    Thread.SpinWait(config.WriterExecutionDelay);
                }
            }
        }

        public override void ReadListCount(object? data)
        {
            var config = (data as ThreadExecutionConfiguration) ?? new ThreadExecutionConfiguration();

            lock (_lockObject)
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
        }
    }
}