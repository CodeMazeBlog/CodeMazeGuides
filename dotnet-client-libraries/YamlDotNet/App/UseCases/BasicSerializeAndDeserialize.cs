using App.Models;
using YamlDotNet.Serialization;

namespace App.UseCases;

public static class BasicSerializeAndDeserialize
{
    public static string SerializeProduct(Product product)
    {
        var serializer = new SerializerBuilder().Build();
        return serializer.Serialize(product);
    }

    public static Product DeserializeProduct(string yaml)
    {
        var deserializer = new DeserializerBuilder().Build();
        return deserializer.Deserialize<Product>(yaml);
    }
}