using System.Diagnostics;
using System.Text.Json;

namespace CustomNamingPolicy
{
    public class CustomNamingPolicy
    {
        public static void Main()
        {
            var person = new Person()
            {
                Name = "Name1",
                SurName = "Surname1"
            };

            var jsonString = JsonSerializer.Serialize(person);
            Console.WriteLine(jsonString);

            var jsonopts = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = new FlatCasePolicy()
            };

            jsonString = JsonSerializer.Serialize(person, jsonopts);
            Console.WriteLine(jsonString);

            jsonopts = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = new CamelCasePolicy()
            };

            jsonString = JsonSerializer.Serialize(person, jsonopts);
            Console.WriteLine(jsonString);
        }
    }
}