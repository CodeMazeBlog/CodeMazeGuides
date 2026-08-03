using WhenToUseReaderWriterLockSlimOverLockInCSharp;

var config = new ThreadExecutionConfiguration
{
    ReaderThreadsCount = 20,
    WriterThreadsCount = 2,
    ReaderExecutionDelay = 100,
    WriterExecutionDelay = 100,
    ReaderExecutionsCount = 100000,
    WriterExecutionsCount = 100000,
};

var lockReadWrite = new LockReadWrite();
Console.WriteLine($"LockReadWrite execution time: {lockReadWrite.Execute(config)} milliseconds.");

var readerWriterLockReadWrite = new ReaderWriterLockReadWrite();
Console.WriteLine($"ReaderWriterLock execution time: {readerWriterLockReadWrite.Execute(config)} milliseconds.");

var readerWriterLockSlimReadWrite = new ReaderWriterLockSlimReadWrite();
Console.WriteLine($"ReaderWriterLockSlim execution time: " +
    $"{readerWriterLockSlimReadWrite.Execute(config)} milliseconds.");