using System.Text.Json;
using CamelCaseSerialization;

// Default
var person = new Person()
{
    Age = 20,
    FirstName = "John",
    Surname = "Doe",
    IsActive = true
};
Console.WriteLine($"{JsonSerializer.Serialize(person)}");

// Entity with Json Attribute
// Serialize
var personWithAttributes = new PersonWithAttributes
{
    Age = 20,
    FirstName = "John",
    Surname = "Doe",
    IsActive = true
};
Console.WriteLine($"{JsonSerializer.Serialize(personWithAttributes)}");
// Deserialize
const string personString = """{"firstName":"John","surname":"Doe","age":20,"isActive":true}""";
var personFromString = JsonSerializer.Deserialize<PersonWithAttributes>(personString);
Console.WriteLine($"{personFromString.FirstName} {personFromString.Surname}({personFromString.IsActive}) is {personFromString.Age}");

// With JsonSerializerOptions param
Console.WriteLine($"{JsonSerializer.Serialize(person, new JsonSerializerOptions
{
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
})}");

// With extension method
Console.WriteLine($"{person.SerializeWithCamelCase()}");

var personObject = personString.DeserializeFromCamelCase<Person>();
Console.WriteLine($"{personObject.FirstName} {personObject.Surname}({personObject.IsActive}) is {personObject.Age}");
