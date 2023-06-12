namespace GetClassNameInCSharp;

public static class CarInfo
{
    public static string DisplayClassNameWithTypeOf()
    {
        return typeof(CarInfo).Name;
    }

    public static string DisplayClassNameWithNameOf()
    {
        return nameof(CarInfo);
    }
}