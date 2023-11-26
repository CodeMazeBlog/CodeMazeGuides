using System.Text.Json;

namespace CustomNamingPolicy;

public class CustomNamingPolicy
{
    public static void Main()
    {
        var person = new Person()
        {
            GivenName = "Name1",
            surName = "Surname1"
        };

        // No custom policy used
        var jsonString = JsonSerializer.Serialize(person);
        Console.WriteLine(jsonString);

        // camelCase Policy used
        var camelCaseOptions = new JsonSerializerOptions()
        {
            PropertyNamingPolicy = new CamelCasePolicy()
        };

        jsonString = JsonSerializer.Serialize(person, camelCaseOptions);
        Console.WriteLine(jsonString);

        // node/separator Policy used
        var nodeOptions = new JsonSerializerOptions()
        {
            PropertyNamingPolicy = new NodeSeparatorPolicy()
        };

        jsonString = JsonSerializer.Serialize(person, nodeOptions);
        Console.WriteLine(jsonString);
    }
}