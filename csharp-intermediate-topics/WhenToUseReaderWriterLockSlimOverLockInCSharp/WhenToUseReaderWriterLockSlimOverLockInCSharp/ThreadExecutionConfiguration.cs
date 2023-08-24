namespace WhenToUseReaderWriterLockSlimOverLockInCSharp
{
    public class ThreadExecutionConfiguration
    {
        public int ReaderThreadsCount { get; set; } // number of threads which will read data from list
        public int WriterThreadsCount { get; set; } // number of threads which will write data to list
        public int ReaderExecutionDelay { get; set; } // amount of milliseconds for delay in reader action
        public int WriterExecutionDelay { get; set; } // amount of milliseconds for delay in writer action
        public int ReaderExecutionsCount { get; set; } // how many times reader will execute action
        public int WriterExecutionsCount { get; set; } // how many times writer will execute action
    }
}