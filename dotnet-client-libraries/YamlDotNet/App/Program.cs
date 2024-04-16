using App.Models;
using App.UseCases;
using YamlDotNet.Core;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NodeDeserializers;

namespace App;

public class Program
{
    public static void Main(string[] args)
    {
        // Serialize and Deserialize Basic Object

        var yamlProduct = SerializeAndDeserialize.Serialize(new Product
        {
            Id = 1,
            Name = "Apple",
            Price = 1.99m
        });
        Console.WriteLine(yamlProduct);

        var deserializeProduct = SerializeAndDeserialize.Deserialize<Product>(yamlProduct);
        Console.WriteLine($"Name: {deserializeProduct.Name}, Price: {deserializeProduct.Price}");

        // Serialize and Deserialize Complex Object

        var yamlStore = SerializeAndDeserialize.Serialize(new Store
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

        Console.WriteLine(yamlStore);

        var deserializeStore = SerializeAndDeserialize.Deserialize<Store>(yamlStore);

        Console.WriteLine($"Store: {deserializeStore.Name}");

        foreach (var item in deserializeStore.Items)
        {
            Console.WriteLine($"Item: {item.Name}, Price: {item.Price}");
            Console.WriteLine($"Manufacturer: {item.Manufacturer.Name}, Country: {item.Manufacturer.Country}");
        }

        // Deserialize and Validate Invalid YAML

        var personYaml = @"Name: ~";
        var deserializer
            = new DeserializerBuilder().WithNodeDeserializer(i => new DeserializerValidation(i),
                                                             s => s.InsteadOf<ObjectNodeDeserializer>()).Build();
        try
        {
            deserializer.Deserialize<Person>(personYaml);
        }
        catch (YamlException e)
        {
            Console.WriteLine($"Unable to deserialize person: {e.Message}");
        }

        // JSON Support in YamlDotNet

        var yamlPerson = """
                         Name: John Doe
                         Age: 25
                         """;
        Console.WriteLine($"Json String: {JsonSupport.SerializeToJson(yamlPerson)}");
    }
}