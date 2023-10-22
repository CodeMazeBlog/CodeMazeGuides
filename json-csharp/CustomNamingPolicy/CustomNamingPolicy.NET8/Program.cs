using System.Text.Json;

namespace CustomNamingPolicy.NET8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConverToSnakeCaseLower();
            ConverToSnakeCaseUpper();
            ConverToKebabCaseLower();
            ConverToKebabCaseUpper();
        }

        private static void ConverToSnakeCaseLower()
        {
            var snakeCaseLowerPolicy = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
            };

            var jsonObj = JsonSerializer.Serialize(new { PropertyName = "value" }, snakeCaseLowerPolicy);
            Console.WriteLine(jsonObj);
        }

        private static void ConverToSnakeCaseUpper()
        {
            var snakeCaseUpperPolicy = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseUpper
            };

            var jsonObj = JsonSerializer.Serialize(new { PropertyName = "value" }, snakeCaseUpperPolicy);
            Console.WriteLine(jsonObj);
        }

        private static void ConverToKebabCaseLower()
        {
            var kebabCaseLowerPolicy = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.KebabCaseLower
            };

            var jsonObj = JsonSerializer.Serialize(new { PropertyName = "value" }, kebabCaseLowerPolicy);
            Console.WriteLine(jsonObj);
        }

        private static void ConverToKebabCaseUpper()
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