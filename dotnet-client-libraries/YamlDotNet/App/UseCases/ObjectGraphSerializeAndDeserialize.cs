using App.Models;
using YamlDotNet.Serialization;

namespace App.UseCases;

public static class ObjectGraphSerializeAndDeserialize
{
    public static string SerializeStore(Store store)
    {
        var serializer = new SerializerBuilder().Build();
        return serializer.Serialize(store);
    }

    public static Store DeserializeStore(string yaml)
    {
        var deserializer = new DeserializerBuilder().Build();
        return deserializer.Deserialize<Store>(yaml);
    }
}