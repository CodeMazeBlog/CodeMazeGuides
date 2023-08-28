namespace ReadStringFromResourceFile;
public sealed class ResourceItem<T>
{
    private readonly string? _errorMessage;
    private readonly T? _item;

    public ResourceItem(T item)
    {
        _item = item;
    }

    public ResourceItem(string errorMessage)
    {
        _errorMessage = errorMessage;
    }

    public T? Item => _item; 
    public bool IsValid => Item != null;
    public string? ErrorMessage => _errorMessage;

    public override string ToString()
    {
        return Item?.ToString() ?? string.Empty;
    }
}

