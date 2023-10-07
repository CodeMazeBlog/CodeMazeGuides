using System.Text.Json;

namespace CustomNamingPolicy.NET8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
            };

            var jsonObj = JsonSerializer.Serialize(new { PropertyName = "value" }, options);
            Console.WriteLine(jsonObj);

            options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.KebabCaseUpper
            };

            jsonObj = JsonSerializer.Serialize(new { PropertyName = "value" }, options);
            Console.WriteLine(jsonObj);
        }
    }
}