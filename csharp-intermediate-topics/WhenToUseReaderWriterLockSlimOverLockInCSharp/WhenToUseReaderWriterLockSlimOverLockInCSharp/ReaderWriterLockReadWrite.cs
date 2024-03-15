namespace WhenToUseReaderWriterLockSlimOverLockInCSharp;

public class ReaderWriterLockReadWrite : BaseReaderWriter
{
    private static readonly ReaderWriterLock ReaderWriterLock = new();

    public override void AddNumbersToList(int writerExecutionsCount, int writerExecutionDelay)
    {
        ReaderWriterLock.AcquireWriterLock(Timeout.InfiniteTimeSpan);

        try
        {
            for (var cnt = 0; cnt < writerExecutionsCount; cnt++)
            {
                NumbersList.Add(cnt);
                Thread.SpinWait(writerExecutionDelay);
            }
        }
        finally
        {
            ReaderWriterLock.ReleaseWriterLock();
        }
    }

    public override void ReadListCount(int readerExecutionsCount, int readerExecutionDelay)
    {
        ReaderWriterLock.AcquireReaderLock(Timeout.InfiniteTimeSpan);

        try
        {
            for (var cnt = 0; cnt < readerExecutionsCount; cnt++)
            {
                if (NumbersList.Count > 0)
                {
                    _ = NumbersList[Random.Shared.Next(0, NumbersList.Count)];
                }
                Thread.SpinWait(readerExecutionDelay);
            }
        }
        finally
        {
            ReaderWriterLock.ReleaseReaderLock();
        }
    }
}