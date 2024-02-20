namespace App;

public static class BatchExtensions
{
    public static List<List<T>> BatchByTraditional<T>(this IEnumerable<T> source, int batchSize)
    {
        var batches = new List<List<T>>();
        var batch = new List<T>(batchSize);
        foreach (var item in source)
        {
            batch.Add(item);
            if (batch.Count != batchSize)
            {
                continue;
            }

            batches.Add(batch);
            batch = new List<T>(batchSize);
        }

        if (batch.Count > 0)
        {
            batches.Add(batch);
        }

        return batches;
    }

    public static List<List<T>> BatchByLinq<T>(this IEnumerable<T> source, int batchSize)
    {
        return source
            .Select((x, i) => new { Index = i, Value = x })
            .GroupBy(x => x.Index / batchSize)
            .Select(x => x.Select(v => v.Value).ToList())
            .ToList();
    }

    public static IEnumerable<IEnumerable<T>> BatchByChunk<T>(this IEnumerable<T> source, int batchSize)
    {
        return source.Chunk(batchSize);
    }
}