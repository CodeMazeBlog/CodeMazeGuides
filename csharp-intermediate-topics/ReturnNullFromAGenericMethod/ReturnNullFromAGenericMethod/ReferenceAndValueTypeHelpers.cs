namespace ReturnNullFromAGenericMethod;

public static class ReferenceAndValueTypeHelpers
{
    public static T? FindItem<T>(List<T> items, T id)
    {
        return default;
    }
}