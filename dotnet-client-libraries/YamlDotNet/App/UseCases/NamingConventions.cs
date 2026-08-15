using YamlDotNet.Serialization;

namespace App.UseCases;

public static class NamingConventions
{
    public static string Serialize<T>(T obj, INamingConvention namingConvention)
    {
        var serializer = new SerializerBuilder()
            .WithNamingConvention(namingConvention)
            .Build();

        return serializer.Serialize(obj);
    }

    public static T Deserialize<T>(string yaml, INamingConvention namingConvention)
    {
        var deserializer = new DeserializerBuilder()
            .WithNamingConvention(namingConvention)
            .Build();

        return deserializer.Deserialize<T>(yaml);
    }
}
