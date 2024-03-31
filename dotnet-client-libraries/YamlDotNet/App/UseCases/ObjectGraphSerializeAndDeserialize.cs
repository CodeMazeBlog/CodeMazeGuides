using App.Models;
using YamlDotNet.Serialization;

namespace App.UseCases;

public static class ObjectGraphSerializeAndDeserialize
{
    public static string SerializeStore(Store store)
    {
        var serializer = new SerializerBuilder().Build();
        var yaml = serializer.Serialize(store);
        return yaml;
    }

    public static Store DeserializeStore(string yaml)
    {
        var deserializer = new DeserializerBuilder().Build();
        var store = deserializer.Deserialize<Store>(yaml);
        return store;
    }
}