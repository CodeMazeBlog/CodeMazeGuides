using WhenToUseReaderWriterLockSlimOverLockInCSharp;

var config = new Configuration
{
    readerThreadsCount = 5,
    writerThreadsCount = 1,
    readerExecutionDelay = 100,
    writerExecutionDelay = 100,
    readerExecutionsCount = 100000,
    writerExecutionsCount = 100000,
};

Console.WriteLine($"LockReadWrite execution time: {LockReadWrite.Execute(config)} milliseconds."); // LockReadWrite execution time: 2763 milliseconds.
Console.WriteLine($"ReaderWriterLock execution time: {ReaderWriterLockReadWrite.Execute(config)} milliseconds."); // ReaderWriterLock execution time: 1906 milliseconds.
Console.WriteLine($"ReaderWriterLockSlim execution time: {ReaderWriterLockSlimReadWrite.Execute(config)} milliseconds."); // ReaderWriterLockSlim execution time: 1171 milliseconds.
Console.ReadKey();