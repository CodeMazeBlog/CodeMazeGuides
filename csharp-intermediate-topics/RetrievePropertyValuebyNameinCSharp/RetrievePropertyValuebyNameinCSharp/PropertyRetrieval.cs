using System.Reflection;

namespace RetrievePropertyValuebyNameinCSharp;
public class PropertyRetrieval
{

    public static bool TryGetPropertyValue<TType, TObj>(TObj obj, string propertyName, out TType? value)
    {
        value = default;

        if (obj is null)
        {
            Console.WriteLine("Object is null.");
            return false;
        }

        PropertyInfo? propertyInfo = typeof(TObj).GetProperty(propertyName);

        if (propertyInfo is null)
        {
            Console.WriteLine($"Property '{propertyName}' not found.");
            return false;
        }

        object? propertyValue = propertyInfo.GetValue(obj);

        if (propertyValue is null && Nullable.GetUnderlyingType(typeof(TType)) is not null)
        {
            return true;
        }

        if (propertyValue is not TType typedValue)
        {
            Console.WriteLine($"Property '{propertyName}' is of type {propertyInfo.PropertyType}, got {typeof(TType)}.");
            return false;
        }

        value = typedValue;

        return true;
    }
}
