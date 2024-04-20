using YamlDotNet.Serialization;

namespace App.UseCases;

public static class SerializeAndDeserialize
{
    public static string Serialize<T>(T obj)
    {
        var serializer = new SerializerBuilder().Build();

        return serializer.Serialize(obj);
    }

    public static T Deserialize<T>(string yaml)
    {
        var deserializer = new DeserializerBuilder().Build();

        return deserializer.Deserialize<T>(yaml);
    }
}