// See https://aka.ms/new-console-template for more information
using RetrievePropertyValuebyNameinCSharp;

Person person = new()
{
    FirstName = "Kevin",
    LastName = "Otim",
    Age = 18,
    IsDeleted = false,
};


PropertyRetrieval.TryGetPropertyValue<int, Person>(person, "Age", out var value);

Console.WriteLine($"Retrieved value: {value}.");