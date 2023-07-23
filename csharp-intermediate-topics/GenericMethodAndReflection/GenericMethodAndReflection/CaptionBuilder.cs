using System.ComponentModel;
using System.Reflection;

namespace GenericMethodAndReflection;

public class CaptionBuilder
{
    public string? ClassCaption<T>()
    {
        var type = typeof(T);

        return type.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName ?? type.Name;
    }

    public static string? StaticCaption<T>() => typeof(T).Name.ToUpper();

    public string? ParentChildCaption<TParent, TChild>()
    {
        var caption1 = ClassCaption<TParent>();
        var caption2 = ClassCaption<TChild>();

        return $"{caption2} of {caption1}";
    }

    public string? ObjectCaption<T>(T obj)
    {
        if (obj is null) return null;

        if (obj.GetType().GetProperty("Name") is { } nameProperty)
            return nameProperty.GetValue(obj)?.ToString();

        return obj?.ToString();
    }

    public string? ComboCaption<T1, T2>(T1 item1, T2 item2) 
    {
        var caption1 = ObjectCaption(item1);
        var caption2 = ObjectCaption(item2);

        return $"{caption1} ({caption2})";
    }

    public string? ComboCaption<T1, T2>(T1 item1, T2 item2, bool capitalize)
    {
        var caption = ComboCaption(item1, item2);

        return capitalize ? caption?.ToUpper() : caption;
    }

    public string? RestrictedCaption<T>() 
        where T : IFormattable
    {
        return typeof(T).Name;
    }
}