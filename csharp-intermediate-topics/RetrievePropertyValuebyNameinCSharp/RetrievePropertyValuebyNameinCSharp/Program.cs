// See https://aka.ms/new-console-template for more information
using RetrievePropertyValuebyNameinCSharp;

Person person = new()
{
    FirstName = "First Name",
    LastName = "Last Name",
    Age = 18,
    IsDeleted = false,
};


PropertyRetrieval.TryGetPropertyValue<int>(person, "Age", out var value);
Console.WriteLine($"Retrieved value: {value}.");