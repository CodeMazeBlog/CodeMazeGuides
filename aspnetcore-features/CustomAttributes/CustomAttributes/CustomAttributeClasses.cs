using System.Reflection;

namespace CustomAttributes;

public static class CustomAttributeHelper
{
    private static void WriteOnTheConsole(Attribute attributeInstance)
    {
        var pInfoList = attributeInstance.GetType().GetProperties(BindingFlags.Public |
                BindingFlags.Instance |
                BindingFlags.DeclaredOnly);

        Console.WriteLine($"\nThe {attributeInstance} attribute:");

        foreach (var pInfo in pInfoList)
            Console.WriteLine($"The {pInfo.Name} property is: {pInfo.GetValue(attributeInstance)}");
    }

    public static string? GetAttribute(Type desiredType, Type desiredAttribute)
    {
        var attributeInstance = Attribute.GetCustomAttribute(desiredType, desiredAttribute);

        if (attributeInstance == null)
            Console.WriteLine($"The class {desiredType} does not have attributes.");
        else
            WriteOnTheConsole(attributeInstance);

        return attributeInstance?.ToString();
    }

    public static T? GetAttributeGeneric<T>(Type desiredType) where T : Attribute
    {
        return desiredType.GetCustomAttribute<T>();
    }

    public static bool HasAttribute<T>(Type desiredType) where T : Attribute
    {
        return desiredType.IsDefined(typeof(T));
    }

    public static List<string> GetAttributesOfMethods(Type elementType)
    {
        var attributes = new List<string>();

        var methodInfoList = elementType.GetMethods(BindingFlags.Public |
            BindingFlags.Instance |
            BindingFlags.DeclaredOnly);

        if (methodInfoList.Length == 0)
        {
            Console.WriteLine($"The type {elementType} does not have any methods.");
            return attributes;
        }

        foreach (var methodInfo in methodInfoList)
        {
            var attributeList = Attribute.GetCustomAttributes(methodInfo, true);

            if (attributeList.Length == 0)
            {
                Console.WriteLine($"The {elementType.Name}.{methodInfo.Name} method does not have attributes.");
                continue;
            }

            Console.WriteLine($"The {elementType.Name}.{methodInfo.Name} method's attribute:");

            foreach (var att in attributeList)
            {
                WriteOnTheConsole(att);
                attributes.Add(methodInfo.Name + "-" + att.ToString());
            }

            Console.WriteLine();
        }

        return attributes;
    }

    public static (int FromAttributeClass, int FromMember) CountInheritedAttributes<T>(MemberInfo member)
        where T : Attribute
    {
        var fromAttributeClass = Attribute.GetCustomAttributes(member, true).OfType<T>().Count();
        var fromMember = member.GetCustomAttributes(true).OfType<T>().Count();

        return (fromAttributeClass, fromMember);
    }
}
