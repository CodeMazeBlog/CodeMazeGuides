using System.Reflection;

namespace RetrievePropertyValuebyNameinCSharp;
public class PropertyRetrieval
{
    public static object GetPropertyValue(object obj, string propertyName)
    {
        PropertyInfo? propertyInfo = obj.GetType().GetProperty(propertyName);

        if (propertyInfo == null)
        {
            Console.WriteLine($"Property {propertyName} not found.");
            return null!;
        }

        return propertyInfo.GetValue(obj)!;
    }

    public static object GetPropertyValue(object obj, string propertyName, Type expectedType)
    {
        PropertyInfo? propertyInfo = obj.GetType().GetProperty(propertyName);

        if (propertyInfo == null)
        {
            Console.WriteLine($"Property {propertyName} not found.");
            return null!;
        }

        object propertyValue = propertyInfo.GetValue(obj)!;

        if (propertyValue == null || propertyValue.GetType() != expectedType)
        {
            Console.WriteLine($"Property {propertyName} has an unexpected type.");
            return null!;
        }

        return propertyValue;
    }

    public static bool TryGetPropertyValue(object obj, string propertyName, out object? propertyValue)
    {
        PropertyInfo? propertyInfo = obj.GetType().GetProperty(propertyName);

        if (propertyInfo != null)
        {
            propertyValue = propertyInfo.GetValue(obj);
            return true;
        }

        Console.WriteLine($"Property {propertyName} not found.");
        propertyValue = null;

        return false;
    }
}
