// See https://aka.ms/new-console-template for more information
using RetrievePropertyValuebyNameinCSharp;

Person person = new()
{
    FirstName = "First Test",
    LastName = "Last Test",
    Age = 18,
    IsDeleted = false,
};

var result = PropertyRetrieval.GetPropertyValue(person, "Age");
Console.WriteLine($"Value is {result}.");