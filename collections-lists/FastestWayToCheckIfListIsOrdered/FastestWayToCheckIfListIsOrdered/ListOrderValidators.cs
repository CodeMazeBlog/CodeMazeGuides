using System.Buffers;
using System.Runtime.InteropServices;

namespace FastestWayToCheckIfListIsOrdered;

public static class ListOrderValidators
{
    public static bool IsOrderedUsingForLoop<T>(List<T> list, IComparer<T>? comparer = default)
    {
        if (list.Count <= 1)
            return true;

        comparer ??= Comparer<T>.Default;

        for (var i = 1; i < list.Count; i++)
        {
            if (comparer.Compare(list[i - 1], list[i]) > 0)
            {
                return false;
            }
        }

        return true;
    }

    public static bool IsOrderedUsingForLoopWithSpan<T>(List<T> list, IComparer<T>? comparer = default)
    {
        if (list.Count <= 1)
            return true;

        comparer ??= Comparer<T>.Default;
        var span = CollectionsMarshal.AsSpan(list);

        for (var i = 1; i < span.Length; i++)
        {
            if (comparer.Compare(span[i - 1], span[i]) > 0)
            {
                return false;
            }
        }

        return true;
    }

    public static bool IsOrderedUsingSpanSort<T>(List<T> list, IComparer<T>? comparer = default)
    {
        if (list.Count <= 1)
            return true;

        T[]? array = null;
        try
        {
            comparer ??= Comparer<T>.Default;

            var listSpan = CollectionsMarshal.AsSpan(list);
            var length = listSpan.Length;

            array = ArrayPool<T>.Shared.Rent(length);
            var arraySpan = array.AsSpan(0, length);
            listSpan.CopyTo(arraySpan);

            arraySpan.Sort(comparer);

            for (var i = 0; i < length; i++)
            {
                if (comparer.Compare(listSpan[i], arraySpan[i]) != 0)
                {
                    return false;
                }
            }

            return true;
        }
        finally
        {
            if (array is not null)
            {
                ArrayPool<T>.Shared.Return(array);
            }
        }
    }

    public static bool IsOrderedUsingEnumerator<T>(IList<T> list, IComparer<T>? comparer = default)
    {
        if (list.Count <= 1)
            return true;

        comparer ??= Comparer<T>.Default;
        var previous = list[0];

        using var enumerator = list.GetEnumerator();
        enumerator.MoveNext();
        while (enumerator.MoveNext())
        {
            var current = enumerator.Current;
            if (comparer.Compare(previous, current) > 0)
            {
                return false;
            }

            previous = current;
        }

        return true;
    }

    public static bool IsOrderedUsingLinqWithSequenceEqual<T>(IList<T> list, IComparer<T>? comparer = default,
        IEqualityComparer<T>? equalityComparer = default)
    {
        if (list.Count <= 1)
            return true;

        comparer ??= Comparer<T>.Default;
        equalityComparer ??= EqualityComparer<T>.Default;

        var orderedList = list.Order(comparer);

        return list.SequenceEqual(orderedList, equalityComparer);
    }

    public static bool IsOrderedUsingLinqWithOrder<T>(IList<T> list, IComparer<T>? comparer = default)
    {
        if (list.Count <= 1)
            return true;

        comparer ??= Comparer<T>.Default;
        var orderedList = list.Order(comparer);

        var index = 0;
        using var enumerator = orderedList.GetEnumerator();
        while (enumerator.MoveNext() && index < list.Count)
        {
            if (comparer.Compare(list[index++], enumerator.Current) != 0)
            {
                return false;
            }
        }

        return true;
    }

    public static bool IsOrderedUsingLinqWithZip<T>(IList<T> list, IComparer<T>? comparer = default)
    {
        if (list.Count <= 1)
            return true;

        comparer ??= Comparer<T>.Default;

        return !list
                .Zip(list.Skip(1), (a, b) => comparer.Compare(a, b) <= 0)
                .Contains(false);
    }

    public static bool IsOrderedUsingParallelFor<T>(IList<T> list, IComparer<T>? comparer = default)
    {
        if (list.Count <= 1)
            return true;

        comparer ??= Comparer<T>.Default;

        var result = Parallel.For(1, list.Count, (index, state) =>
        {
            if (!state.IsStopped && comparer.Compare(list[index - 1], list[index]) > 0)
                state.Stop();
        });

        return result.IsCompleted;
    }

    public static bool IsOrderedUsingParallelForPartitioned<T>(List<T> list, IComparer<T>? comparer = default)
    {
        const int minPartitionLength = 4;

        if (list.Count <= 1)
            return true;

        comparer ??= Comparer<T>.Default;

        var length = list.Count;
        var maxPartitions = 1 + (length - 1) / minPartitionLength;
        var partitions = Math.Min(Environment.ProcessorCount, maxPartitions);

        if (partitions == 1)
            return IsOrderedUsingForLoopWithSpan(list, comparer);

        var partitionSize = 1 + (length - 1) / partitions;
        var options = new ParallelOptions { MaxDegreeOfParallelism = partitions };
        var result = Parallel.For(0, partitions, options,
            (partitionIndex, state) =>
            {
                var low = partitionIndex * partitionSize;
                var high = Math.Min(length, low + partitionSize + 1) - 1;
                for (var i = low; i < high && !state.IsStopped; i++)
                {
                    if (comparer.Compare(list[i], list[i + 1]) > 0)
                        state.Stop();
                }
            });

        return result.IsCompleted;
    }

    public static bool IsOrderedUsingParallelForPartitionedWithSpans<T>(
        List<T> list, IComparer<T>? comparer = default)
    {
        const int minPartitionLength = 4;

        if (list.Count <= 1)
            return true;

        comparer ??= Comparer<T>.Default;

        var length = list.Count;
        var maxPartitions = 1 + (length - 1) / minPartitionLength;
        var partitions = Math.Min(Environment.ProcessorCount, maxPartitions);

        if (partitions == 1)
            return IsOrderedUsingForLoopWithSpan(list, comparer);

        var partitionSize = 1 + (length - 1) / partitions;
        var options = new ParallelOptions { MaxDegreeOfParallelism = partitions };
        var result = Parallel.For(0, partitions, options,
            (partitionIndex, state) =>
            {
                var low = partitionIndex * partitionSize;
                if (low >= length)
                    return;

                var high = Math.Min(length, low + partitionSize + 1);
                var span = CollectionsMarshal.AsSpan(list)[low..high];
                for (var i = 0; i < span.Length - 1 && !state.IsStopped; i++)
                {
                    if (comparer.Compare(span[i], span[i + 1]) > 0)
                        state.Stop();
                }
            });

        return result.IsCompleted;
    }
}