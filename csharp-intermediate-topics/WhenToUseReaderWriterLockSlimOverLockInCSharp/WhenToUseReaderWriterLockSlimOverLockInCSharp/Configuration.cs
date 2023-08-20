namespace WhenToUseReaderWriterLockSlimOverLockInCSharp
{
    public class Configuration
    {
        public int readerThreadsCount = 5; // number of threads which will read data from list
        public int writerThreadsCount = 1; // number of threads which will write data to list
        public int readerExecutionDelay = 100; // amount of milliseconds for delay in reader action
        public int writerExecutionDelay = 100; // amount of milliseconds for delay in writer action
        public int readerExecutionsCount = 100000; // how many times reader will execute action
        public int writerExecutionsCount = 100000; // how many times writer will execute action
    }
}