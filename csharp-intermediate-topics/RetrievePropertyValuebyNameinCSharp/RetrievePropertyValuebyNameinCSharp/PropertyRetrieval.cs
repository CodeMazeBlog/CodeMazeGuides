using System.Reflection;

namespace RetrievePropertyValuebyNameinCSharp;
public class PropertyRetrieval
{

    public static bool TryGetPropertyValue<T>(object obj, string propertyName, out T? value)
    {
        value = default;

        if (obj is null)
        {
            Console.WriteLine("Object is null.");
            return false;
        }

        PropertyInfo? propertyInfo = obj.GetType().GetProperty(propertyName);

        if (propertyInfo == null)
        {
            Console.WriteLine($"Property '{propertyName}' not found.");
            return false;
        }

        object? propertyValue = propertyInfo.GetValue(obj);

        if (propertyValue is null && Nullable.GetUnderlyingType(typeof(T)) != null)
        {
            return true;
        }

        if (propertyValue is not T typedValue)
        {
            Console.WriteLine($"Property '{propertyName}' is of type {propertyInfo.PropertyType}, got {typeof(T)}.");
            return false;
        }

        value = typedValue;

        return true;
    }
}
