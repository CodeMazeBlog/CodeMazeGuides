namespace WhenToUseReaderWriterLockSlimOverLockInCSharp;

public class LockReadWrite : BaseReaderWriter
{
    private static readonly object LockObject = new();

    public override void AddNumbersToList(int writerExecutionsCount, int writerExecutionDelay)
    {
        lock (LockObject)
        {
            for (var cnt = 0; cnt < writerExecutionsCount; cnt++)
            {
                NumbersList.Add(cnt);
                Thread.SpinWait(writerExecutionDelay);
            }
        }
    }

    public override void ReadListCount(int readerExecutionsCount, int readerExecutionDelay)
    {
        lock (LockObject)
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
    }
}