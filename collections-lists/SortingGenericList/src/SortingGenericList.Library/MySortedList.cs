using System.Collections;
using System.Runtime.InteropServices;

namespace SortingGenericList.Library;

public sealed class MySortedList<T> : IList<T>
    where T : IComparable<T>
{
    private readonly IComparer<T>? _comparer;
    private readonly List<T> _list;

    public int Capacity => _list.Capacity;

    public int Count => _list.Count;

    public bool IsReadOnly => false;

    public T this[int index]
    {
        get => _list[index];
        set => throw new NotSupportedException();
    }

    public MySortedList(int capacity = 0, IComparer<T>? comparer = null)
    {
        _list = new List<T>(capacity);
        _comparer = comparer;
    }

    public MySortedList(IEnumerable<T> initialValues, IComparer<T>? comparer = null)
        : this(comparer: comparer)
        => AddRange(initialValues);

    public void AddRange(IEnumerable<T> items)
    {
        _list.AddRange(items);
        _list.Sort(_comparer);
    }

    public void CopyTo(Span<T> dest)
    {
        var source = CollectionsMarshal.AsSpan(_list);
        source.CopyTo(dest);
    }

    public T[] ToArray() => _list.ToArray();

    public int IndexOf(T item)
    {
        var index = _list.BinarySearch(item, _comparer);

        return index < 0 ? -1 : index;
    }

    public void Insert(int index, T item)
    {
        throw new NotSupportedException();
    }

    public void RemoveAt(int index)
    {
        _list.RemoveAt(index);
    }

    public IEnumerator<T> GetEnumerator() => _list.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public void Add(T item)
    {
        var index = _list.BinarySearch(item, _comparer);
        if (index < 0) index = ~index;

        _list.Insert(index, item);
    }

    public void Clear()
    {
        _list.Clear();
    }

    public bool Contains(T item) => _list.BinarySearch(item, _comparer) >= 0;

    public void CopyTo(T[] array, int arrayIndex)
    {
        _list.CopyTo(array, arrayIndex);
    }

    public bool Remove(T item)
    {
        var index = _list.BinarySearch(item, _comparer);

        if (index < 0) return false;

        _list.RemoveAt(index);

        return true;
    }
}