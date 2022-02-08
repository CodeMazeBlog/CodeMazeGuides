// TODO how to get the environments.
// Our very basic collection.
public class CustomCollection<T> : IComparable<CustomCollection<T>> where T : IComparable<T>
{
    private T[] _items;

    public CustomCollection(T[] items)
    {
        _items = items;
    }

    public void Transform(Action<T> transform)
    {
        foreach(var item in _items)
        {
            transform(item);
        }
    }

    public CustomCollection<T> Filter(Func<T, bool> filter)
    {
        T[] newCollection = new T[_items.Length];   // That's the most that we know of 
        int insertIndex = 0;

        for (int i = 0; i < _items.Length; ++i)
        {
            if (filter(_items[i]))
            {
                newCollection[insertIndex++] = _items[i];
            }
        }

        // Rebuild the temp collection.
        Array.Resize(ref newCollection, insertIndex);

        return new CustomCollection<T>(newCollection);
    }

    public int CompareTo(CustomCollection<T>? other)
    {
        int indexOne, indexTwo;
        int difference;

        if (other == null)
        {
            throw new ArgumentNullException(nameof(other));
        }

        for (indexOne = 0, indexTwo = 0; indexOne < _items.Length && indexTwo < other?._items.Length; ++indexOne, ++indexTwo)
        {
            difference = _items[indexOne].CompareTo(other._items[indexTwo]);
            if (difference != 0)
            {
                return difference;
            }
        }

        // Comes down to whether the length is all the same or not.
        difference = _items.Length - other._items.Length;

        return difference;
    }
}
