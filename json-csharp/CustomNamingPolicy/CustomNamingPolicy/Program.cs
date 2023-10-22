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

            var flatCaseOptions = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = new FlatCasePolicy()
            };

            jsonString = JsonSerializer.Serialize(person, flatCaseOptions);
            Console.WriteLine(jsonString);

            var camelCaseOptions = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = new CamelCasePolicy()
            };

            jsonString = JsonSerializer.Serialize(person, camelCaseOptions);
            Console.WriteLine(jsonString);
        }
    }
}