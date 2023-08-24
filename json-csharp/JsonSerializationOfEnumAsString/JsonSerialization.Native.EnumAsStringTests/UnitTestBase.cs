global using Xunit;
global using System.Text.Json;
global using System.Text.Json.Serialization;

namespace JsonSerialization.Native.EnumAsStringTests;

public abstract class UnitTestBase
{
    public static string Serialize(object obj)
    {
        return JsonSerializer.Serialize(obj);
    }

    public static string SerializeWithStringEnum(object obj)
    {
        var options = new JsonSerializerOptions();
        options.Converters.Add(new JsonStringEnumConverter());

        return JsonSerializer.Serialize(obj, options);
    }
}