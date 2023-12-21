// See https://aka.ms/new-console-template for more information
using RetrievePropertyValuebyNameinCSharp;

Person person = new()
{
    FirstName = "First Test",
    LastName = "Last Test",
    Age = 18,
    IsDeleted = false,
};


PropertyRetrieval.TryGetPropertyValue<int>(person, "Age", out var value);
Console.WriteLine($"Retrieved value: {value}.");

var result = PropertyRetrieval.TryGetPrivateFieldValue<Guid>(person, "_id", out var data);
Console.WriteLine($"Retrieved value: {result}.");