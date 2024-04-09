using App.Models;
using App.UseCases;
using YamlDotNet.Core;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NodeDeserializers;
using static System.Console;

namespace App;

public class Program
{
    public static void Main(string[] args)
    {
        // Serialize and Deserialize Basic Object

        var yamlProduct = BasicSerializeAndDeserialize.SerializeProduct(new Product
        {
            Id = 1,
            Name = "Apple",
            Price = 1.99m
        });
        WriteLine(yamlProduct);

        var deserializeProduct = BasicSerializeAndDeserialize.DeserializeProduct(yamlProduct);
        WriteLine($"Name: {deserializeProduct.Name}, Price: {deserializeProduct.Price}");

        // Serialize and Deserialize Complex Object

        var yamlStore = ObjectGraphSerializeAndDeserialize.SerializeStore(new Store
        {
            Name = "Tech Store",
            Items =
            [
                new Item
                {
                    Name = "Laptop",
                    Price = 1000m,
                    Manufacturer = new Manufacturer
                    {
                        Name = "Tech Corp",
                        Country = "USA"
                    }
                },
                new Item
                {
                    Name = "Smartphone",
                    Price = 500m,
                    Manufacturer = new Manufacturer
                    {
                        Name = "Mobile Inc",
                        Country = "China"
                    }
                }
            ]
        });

        WriteLine(yamlStore);

        var deserializeStore = ObjectGraphSerializeAndDeserialize.DeserializeStore(yamlStore);

        WriteLine($"Store: {deserializeStore.Name}");

        foreach (var item in deserializeStore.Items)
        {
            WriteLine($"Item: {item.Name}, Price: {item.Price}");
            WriteLine($"Manufacturer: {item.Manufacturer.Name}, Country: {item.Manufacturer.Country}");
        }

        // Deserialize and Validate Invalid YAML

        var personYaml = @"Name: ~";
        var deserializer = new DeserializerBuilder().WithNodeDeserializer
        (i => new DeserializerValidation(i),
            s => s.InsteadOf<ObjectNodeDeserializer>()).Build();
        try
        {
            deserializer.Deserialize<Person>(personYaml);
        }
        catch (YamlException e)
        {
            WriteLine($"Unable to deserialize person: {e.InnerException?.Message}");
        }

        // JSON Support in YamlDotNet

        var yamlPerson = """
                         Name: John Doe
                         Age: 25
                         """;
        WriteLine($"Json String: {JsonSupport.SerializeToJson(yamlPerson)}");
    }
}