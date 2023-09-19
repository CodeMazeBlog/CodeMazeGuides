namespace WhenToUseReaderWriterLockSlimOverLockInCSharp;

public class ThreadExecutionConfiguration
{
    public int ReaderThreadsCount { get; init; }
    public int WriterThreadsCount { get; init; }
    public int ReaderExecutionDelay { get; init; }
    public int WriterExecutionDelay { get; init; }
    public int ReaderExecutionsCount { get; init; }
    public int WriterExecutionsCount { get; init; }
}