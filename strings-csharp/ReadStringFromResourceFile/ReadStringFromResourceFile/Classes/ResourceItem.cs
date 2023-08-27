namespace ReadStringFromResourceFile;
public class ResourceItem<T>
{
    private T? _item;

    public ResourceItem(T? item = default(T))
    {
        _item = item;
    }

    public T? Item { get => _item; }
    public bool IsValid => Item != null;

    public override string ToString()
    {
        return Item?.ToString() ?? string.Empty;
    }
}

