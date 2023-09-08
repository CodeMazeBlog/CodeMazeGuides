namespace WhenToUseReaderWriterLockSlimOverLockInCSharp;

using System.Diagnostics;

public abstract class BaseReaderWriter
{
    protected readonly List<int> NumbersList = new();

    public List<int> ListOfNumbers => NumbersList;

    public long Execute(ThreadExecutionConfiguration config)
    {
        var tasks = new List<Task>();

        for (var cnt = 0; cnt < config.ReaderThreadsCount; cnt++)
        {
            var readTask = new Task(() => ReadListCount(config.ReaderExecutionsCount, config.ReaderExecutionDelay));
            tasks.Add(readTask);
        }

        for (var cnt = 0; cnt < config.WriterThreadsCount; cnt++)
        {
            var writeTask = new Task(() => AddNumbersToList(config.WriterExecutionsCount, config.WriterExecutionDelay));
            tasks.Add(writeTask);
        }

        var stopwatch = new Stopwatch();
        stopwatch.Start();

        foreach (var task in tasks)
        {
            task.Start();
        }

        Task.WhenAll(tasks).Wait();

        stopwatch.Stop();

        return stopwatch.ElapsedMilliseconds;
    }

    public abstract void AddNumbersToList(int writerExecutionsCount, int writerExecutionDelay);

    public abstract void ReadListCount(int readerExecutionsCount, int readerExecutionDelay);
}