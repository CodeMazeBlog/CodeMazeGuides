global using Xunit;
global using Newtonsoft.Json;
global using Newtonsoft.Json.Converters;
global using Newtonsoft.Json.Serialization;

namespace JsonSerialization.Newtonsoft.EnumAsStringTests;

public abstract class UnitTestBase
{
    public static string Serialize(object obj)
    {
        return JsonConvert.SerializeObject(obj);
    }

    public static string SerializeWithStringEnum(object obj)
    {
        var converter = new StringEnumConverter();
        return JsonConvert.SerializeObject(obj, converter);
    }
}