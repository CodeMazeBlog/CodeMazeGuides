using System.Text.Json;
using CustomNamingPolicy;

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

// Built-in policies
ConvertToSnakeCaseLower();
ConvertToSnakeCaseUpper();
ConvertToKebabCaseLower();
ConvertToKebabCaseUpper();

static void ConvertToSnakeCaseLower()
{
    var snakeCaseLowerPolicy = new JsonSerializerOptions
    {
        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
    };

    var jsonObj = JsonSerializer.Serialize(new { PropertyName = "value" }, snakeCaseLowerPolicy);
    Console.WriteLine(jsonObj);
}

static void ConvertToSnakeCaseUpper()
{
    var snakeCaseUpperPolicy = new JsonSerializerOptions
    {
        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseUpper
    };

    var jsonObj = JsonSerializer.Serialize(new { PropertyName = "value" }, snakeCaseUpperPolicy);
    Console.WriteLine(jsonObj);
}

static void ConvertToKebabCaseLower()
{
    var kebabCaseLowerPolicy = new JsonSerializerOptions
    {
        PropertyNamingPolicy = JsonNamingPolicy.KebabCaseLower
    };

    var jsonObj = JsonSerializer.Serialize(new { PropertyName = "value" }, kebabCaseLowerPolicy);
    Console.WriteLine(jsonObj);
}

static void ConvertToKebabCaseUpper()
{
    var kebabCaseUpperPolicy = new JsonSerializerOptions
    {
        PropertyNamingPolicy = JsonNamingPolicy.KebabCaseUpper
    };

    var jsonObj = JsonSerializer.Serialize(new { PropertyName = "value" }, kebabCaseUpperPolicy);
    Console.WriteLine(jsonObj);
}
