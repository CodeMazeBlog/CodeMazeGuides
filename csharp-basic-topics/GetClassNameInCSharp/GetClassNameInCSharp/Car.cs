using System.Reflection;

namespace GetClassNameInCSharp;

public class Car
{
    public string DisplayClassNameWithGetType()
    {
        return GetType().Name;
    }

    public string DisplayClassNameWithTypeOf()
    {
        return typeof(Car).Name;
    }

    public string DisplayClassNameWithNameOf()
    {
        return nameof(Car);
    }

    public string? DisplayClassNameWithReflection()
    {
        return MethodBase.GetCurrentMethod()?.DeclaringType?.Name;
    }
}
