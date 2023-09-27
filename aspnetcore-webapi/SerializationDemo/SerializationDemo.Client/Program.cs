// See https://aka.ms/new-console-template for more information
using SerializationDemo.Client.Clients;
using SerializationDemo.Common.Models;


Console.Write("Enter a format name(json, cache, xml, proto): ");
string? format = Console.ReadLine();
format = format?.Trim().ToLower();

IClient client = format switch
{
    "json" => new JsonClient(),
    "cache" => new CachedJsonClient(),
    "xml" => new XmlClient(),
    "proto" => new ProtobufClient(),
    _ => new JsonClient()
};

Console.WriteLine("Employee list before adding employee.");
Console.WriteLine("--------------------------------------");
PrintAllEmployees(client);
CreateEmployee(client);
Console.WriteLine();
Console.WriteLine("Employee list after adding employee.");
Console.WriteLine("--------------------------------------");
PrintAllEmployees(client);

static void PrintAllEmployees(IClient client)
{
    var employees = client.GetAllEmployees().Result;
    foreach (var employee in employees)
    {
        Console.WriteLine($"Name:{employee.Name}");
        Console.WriteLine($"Address:{employee?.Address?.AddressLine1}, {employee?.Address?.AddressLine2}, {employee?.Address?.City}, {employee?.Address?.Country}");
        Console.WriteLine();
        Console.WriteLine();
    }
}

static void CreateEmployee(IClient client)
{
    var employee = new Employee
    {
        Id = Guid.NewGuid(),
        Name = $"TestEmployee6",
        Address = new Address
        {
            AddressLine1 = $"Street #6",
            AddressLine2 = $"District #6",
            City = $"Sample City30",
            Country = $"Sample Country22",
        }
    };

    var neweEmployee = client.CreateEmployee(employee).Result;
    Console.WriteLine($"New employee {neweEmployee?.Name} has been added");
}