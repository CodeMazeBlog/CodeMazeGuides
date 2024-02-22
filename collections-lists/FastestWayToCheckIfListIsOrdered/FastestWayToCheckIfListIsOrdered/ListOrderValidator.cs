using System.Buffers;
using System.Runtime.InteropServices;

namespace FastestWayToCheckIfListIsOrdered;

public class ListOrderValidator
{
    public static bool IsOrderedUsingForLoop<T>(IList<T> list, IComparer<T>? comparer = default)
    {
        if (list.Count <= 1) return true;

        comparer ??= Comparer<T>.Default;
        int length = list.Count;
        for (int i = 1; i < length; i++)
        {
            if (comparer.Compare(list[i - 1], list[i]) > 0) return false;
        }

        return true;
    }

    public static bool IsOrderedUsingArraySort<T>(IList<T> list, ArrayPool<T> pool, IComparer<T>? comparer = default)
    {
        if (list.Count <= 1) return true;

        comparer ??= Comparer<T>.Default;

        int length = list.Count;

        var array = pool.Rent(length);
        list.CopyTo(array, 0);

        Array.Sort(array, 0, length, comparer);
        for (int i = 0; i < length; i++)
        {
            if (comparer.Compare(list[i], array[i]) != 0) return false;
        }

        pool.Return(array);
        return true;
    }

    public static bool IsOrderedUsingSpans<T>(List<T> list, IComparer<T>? comparer = default)
    {
        comparer ??= Comparer<T>.Default;
        var span = CollectionsMarshal.AsSpan(list);

        int length = span.Length;
        for (int i = 1; i < length; i++)
        {
            if (comparer.Compare(span[i - 1], span[i]) > 0) return false;
        }

        return true;
    }

    public static bool IsOrderedUsingEnumerator<T>(IList<T> list, IComparer<T>? comparer = default)
    {
        if (list.Count <= 1) return true;

        comparer ??= Comparer<T>.Default;
        var previous = list[0];

        using var enumerator = list.GetEnumerator();
        enumerator.MoveNext();
        while (enumerator.MoveNext())
        {
            var current = enumerator.Current;
            if (comparer.Compare(previous, current) > 0) return false;
            previous = current;
        }

        return true;
    }

    public static bool IsOrderedUsingLinqWithSequenceEqual<T>(IList<T> list, IComparer<T>? comparer = default)
    {
        if (list.Count <= 1) return true;

        comparer ??= Comparer<T>.Default;
        var orderedList = list.Order(comparer);
        return list.SequenceEqual(orderedList);
    }

    public static bool IsOrderedUsingLinqWithOrder<T>(IList<T> list, IComparer<T>? comparer = default)
    {
        if (list.Count <= 1) return true;

        comparer ??= Comparer<T>.Default;
        var orderedList = list.Order(comparer);

        using var enumerator = orderedList.GetEnumerator();
        enumerator.MoveNext();

        int length = list.Count;
        for (int i = 0; i < length; i++)
        {
            if (comparer.Compare(list[i], enumerator.Current) != 0) return false;
            enumerator.MoveNext();
        }

        return true;
    }

    public static bool IsOrderedUsingLinqWithZip<T>(IList<T> list, IComparer<T>? comparer = default)
    {
        comparer ??= Comparer<T>.Default;
        return !list
            .Zip(list.Skip(1), (a, b) => comparer.Compare(a, b) <= 0)
            .Contains(false);
    }


    public static bool IsOrderedUsingParallelFor<T>(IList<T> list, IComparer<T>? comparer = default)
    {
        if (list.Count <= 1) return true;
        comparer ??= Comparer<T>.Default;

        bool ordered = true;
        Parallel.For(1, list.Count, (index, state) =>
        {
            if (comparer.Compare(list[index - 1], list[index]) > 0 && !state.IsStopped)
            {
                ordered = false;
                state.Stop();
            }
        });

        return ordered;
    }

    public static unsafe bool IsOrderedUsingParallelForWithSpans<T>(List<T> list, IComparer<T>? comparer = default)
    {
        if (list.Count <= 1) return true;
        comparer ??= Comparer<T>.Default;

        var span = CollectionsMarshal.AsSpan(list);
        var length = span.Length;

        ParallelLoopResult result;
        fixed (void* ptr = span)
        {
            var @fixed = ptr;
            result = Parallel.For(1, length, (index, state) =>
                Body(index, state, new Span<T>(@fixed, length), comparer));
        }

        void Body<T2>(int index, ParallelLoopState state, Span<T2> span, IComparer<T2> comparer)
        {
            if (comparer.Compare(span[index - 1], span[index]) > 0 && !state.IsStopped)
            {
                state.Stop();
            }
        }

        return result.IsCompleted;
    }

    public static bool IsOrderedUsingParallelForPartitioned<T>(
        List<T> list,
        IComparer<T>? comparer = default)
    {
        if (list.Count <= 1) return true;
        comparer ??= Comparer<T>.Default;

        var length = list.Count;
        var partitions = Environment.ProcessorCount;
        var partitionSize = (int)Math.Ceiling((double)length / partitions);

        var options = new ParallelOptions { MaxDegreeOfParallelism = partitions };
        var result = Parallel.For(0, partitions, options, (partitionIndex, state) =>
        {
            var low = Math.Max(1, partitionIndex * partitionSize + 1);
            var high = Math.Min(length - 1, low + partitionSize - 1);
            for (int i = low; i <= high && !state.IsStopped; i++)
            {
                if (comparer.Compare(list[i - 1], list[i]) > 0) state.Stop();
            }
        });

        return result.IsCompleted;
    }

    public static unsafe bool IsOrderedUsingParallelForPartitionedWithSpans<T>(
        List<T> list,
        IComparer<T>? comparer = default)
    {
        if (list.Count <= 1) return true;
        comparer ??= Comparer<T>.Default;

        var length = list.Count;
        var span = CollectionsMarshal.AsSpan(list);
        var partitions = Environment.ProcessorCount;
        var partitionSize = (int)Math.Ceiling((double)length / partitions);

        var options = new ParallelOptions { MaxDegreeOfParallelism = partitions };
        ParallelLoopResult result;
        fixed (void* ptr = span)
        {
            var @fixed = ptr;
            result = Parallel.For(0, partitions, options,
                (partitionIndex, state) => Body(partitionIndex, state, new Span<T>(@fixed, length), comparer));
        }

        void Body<T2>(int partitionIndex, ParallelLoopState state, Span<T2> span, IComparer<T2> comparer)
        {
            var low = Math.Max(1, partitionIndex * partitionSize + 1);
            var high = Math.Min(length - 1, low + partitionSize - 1);
            for (int i = low; i <= high && !state.IsStopped; i++)
            {
                if (comparer.Compare(span[i - 1], span[i]) > 0) state.Stop();
            }
        }

        return result.IsCompleted;
    }
}