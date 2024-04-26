using YamlDotNet.Serialization;

namespace App.UseCases;

public static class JsonSupport
{
    public static string SerializeToJson(string yaml)
    {
        var deserializer = new DeserializerBuilder().Build();
        var yamlObject = deserializer.Deserialize(yaml);
        var serializer = new SerializerBuilder().JsonCompatible().Build();
        return serializer.Serialize(yamlObject);
    }
}