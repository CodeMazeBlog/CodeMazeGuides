using System.Reflection;

namespace RetrievePropertyValuebyNameinCSharp;
public class PropertyRetrieval
{
    public static object GetPropertyValue(object obj, string propertyName)
    {
        PropertyInfo propertyInfo = obj.GetType().GetProperty(propertyName);

        if (propertyInfo != null)
        {
            return propertyInfo.GetValue(obj);
        }
        else
        {
            Console.WriteLine($"Property {propertyName} not found.");
            return null;
        }
    }

    public static object GetPropertyValue(object obj, string propertyName, Type expectedType)
    {
        PropertyInfo propertyInfo = obj.GetType().GetProperty(propertyName);

        if (propertyInfo != null)
        {
            object propertyValue = propertyInfo.GetValue(obj);

            if (propertyValue != null && propertyValue.GetType() == expectedType)
            {
                return propertyValue;
            }
            else
            {
                Console.WriteLine($"Property {propertyName} has an unexpected type.");
                return null;
            }
        }

        Console.WriteLine($"Property {propertyName} not found.");
        return null;
    }
}
