namespace ReadStringFromResourceFile;
public class ResourceItem<T>
{
    private T? item;

    public ResourceItem(T? item = default(T))
    {
        this.item = item;
    }

    public T? Item { get => item; }
    public bool IsValid => Item != null;

    public override string ToString()
    {
        return Item?.ToString() ?? string.Empty;
    }
}

