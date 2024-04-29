using System.Text.Json;

namespace CustomNamingPolicy.NET8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConvertToSnakeCaseLower();
            ConvertToSnakeCaseUpper();
            ConvertToKebabCaseLower();
            ConvertToKebabCaseUpper();
        }

        private static void ConvertToSnakeCaseLower()
        {
            var snakeCaseLowerPolicy = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
            };

            var jsonObj = JsonSerializer.Serialize(new { PropertyName = "value" }, snakeCaseLowerPolicy);
            Console.WriteLine(jsonObj);
        }

        private static void ConvertToSnakeCaseUpper()
        {
            var snakeCaseUpperPolicy = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseUpper
            };

            var jsonObj = JsonSerializer.Serialize(new { PropertyName = "value" }, snakeCaseUpperPolicy);
            Console.WriteLine(jsonObj);
        }

        private static void ConvertToKebabCaseLower()
        {
            var kebabCaseLowerPolicy = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.KebabCaseLower
            };

            var jsonObj = JsonSerializer.Serialize(new { PropertyName = "value" }, kebabCaseLowerPolicy);
            Console.WriteLine(jsonObj);
        }

        private static void ConvertToKebabCaseUpper()
        {
            var kebabCaseUpperPolicy = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.KebabCaseUpper
            };

            var jsonObj = JsonSerializer.Serialize(new { PropertyName = "value" }, kebabCaseUpperPolicy);
            Console.WriteLine(jsonObj);
        }
    }
}