namespace ReturnNullFromAGenericMethod;

public static class ReferenceAndValueTypeHelpers
{
    public static T? FindItemOrDefault<T>(List<T> items, T id)
    {
        return default;
    }
}