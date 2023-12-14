using System;
using System.Linq;

namespace GenericMethodAndReflection.Tests;

public class NonGenericCaptionBuilder
{
    private readonly CaptionBuilder _captionBuilder = new();

    public string? ClassCaption(Type type)
    {
        var baseMethod = typeof(CaptionBuilder)
            .GetMethod(nameof(CaptionBuilder.ClassCaption))!;

        var genericMethod = baseMethod.MakeGenericMethod(type)!;

        return (string?)genericMethod.Invoke(_captionBuilder, Array.Empty<object>());
    }

    public static string? StaticCaption(Type type)
    {
        var baseMethod = typeof(CaptionBuilder)
            .GetMethod(nameof(CaptionBuilder.StaticCaption))!;

        var genericMethod = baseMethod.MakeGenericMethod(type)!;

        return (string?)genericMethod.Invoke(null, Array.Empty<object>())!;
    }

    public string? ParentChildCaption(Type parentType, Type childType)
    {
        var baseMethod = typeof(CaptionBuilder)
            .GetMethod(nameof(CaptionBuilder.ParentChildCaption))!;

        var genericMethod = baseMethod.MakeGenericMethod(parentType, childType)!;

        return (string?)genericMethod.Invoke(_captionBuilder, Array.Empty<object>());
    }

    public string? ObjectCaption(object obj)
    {
        if (obj is null) return null;

        var baseMethod = typeof(CaptionBuilder)
            .GetMethod(nameof(CaptionBuilder.ObjectCaption))!;

        var genericMethod = baseMethod.MakeGenericMethod(obj.GetType())!;

        return (string?)genericMethod.Invoke(_captionBuilder, new object[] { obj })!;
    }

    public string? ComboCaption(object item1, object item2, bool capitalize)
    {
        var baseMethod = typeof(CaptionBuilder)
            .GetMethods()
            .Single(m =>
                m.Name == nameof(CaptionBuilder.ComboCaption)
                && m.GetParameters().Length == 3);

        var genericMethod = baseMethod.MakeGenericMethod(item1.GetType(), item2.GetType())!;

        return (string?)genericMethod.Invoke(_captionBuilder, new object[] { item1, item2, capitalize })!;
    }

    public string? RestrictedCaption(Type type)
    {
        var baseMethod = typeof(CaptionBuilder)
            .GetMethod(nameof(CaptionBuilder.RestrictedCaption))!;

        var genericMethod = baseMethod.MakeGenericMethod(type)!;

        return (string?)genericMethod.Invoke(_captionBuilder, Array.Empty<object>());
    }

    public string? ImprovedRestrictedCaption(Type type)
    {
        if (!typeof(IFormattable).IsAssignableFrom(type))
            throw new NotSupportedException($"{type.Name} does not implement IFormattable interface");

        var baseMethod = typeof(CaptionBuilder)
            .GetMethod(nameof(CaptionBuilder.RestrictedCaption))!;

        var genericMethod = baseMethod.MakeGenericMethod(type)!;

        return (string?)genericMethod.Invoke(_captionBuilder, Array.Empty<object>());
    }
}