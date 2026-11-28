using System.Collections.Concurrent;

namespace ExampleApp.ListAndSetExamples;

public static class ListAndSetAlternatives
{
    public static int CountUniqueIds(int workers, int idsPerWorker)
    {
        var seenIds = new ConcurrentDictionary<int, byte>();

        Parallel.For(0, workers, _ =>
        {
            for (var id = 0; id < idsPerWorker; id++)
            {
                seenIds.TryAdd(id, 0);
            }
        });

        return seenIds.Count;
    }

    public static int AppendToQueue(int workers, int itemsPerWorker)
    {
        var entries = new ConcurrentQueue<int>();

        Parallel.For(0, workers, worker =>
        {
            for (var i = 0; i < itemsPerWorker; i++)
            {
                entries.Enqueue(worker * itemsPerWorker + i);
            }
        });

        return entries.Count;
    }

    public static int AppendToLockedList(int workers, int itemsPerWorker)
    {
        var numbers = new List<int>();
        var numbersLock = new Lock();

        Parallel.For(0, workers, worker =>
        {
            for (var i = 0; i < itemsPerWorker; i++)
            {
                lock (numbersLock)
                {
                    numbers.Add(worker * itemsPerWorker + i);
                }
            }
        });

        return numbers.Count;
    }
}
