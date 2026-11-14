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

Console.WriteLine();
Console.WriteLine("Employee list before adding an employee.");
Console.WriteLine("--------------------------------------");
await PrintAllEmployees(client);
await CreateEmployee(client);
Console.WriteLine();
Console.WriteLine("Employee list after adding an employee.");
Console.WriteLine("--------------------------------------");
await PrintAllEmployees(client);

static async Task PrintAllEmployees(IClient client)
{
    var employees = await client.GetAllEmployees();
    foreach (var employee in employees)
    {
        Console.WriteLine($"Name:{employee.Name}");
        Console.WriteLine($"Address:{employee.Address?.AddressLine1}, {employee.Address?.AddressLine2}, {employee.Address?.City}, {employee.Address?.Country}");
        Console.WriteLine();
    }
}

static async Task CreateEmployee(IClient client)
{
    var employee = new Employee
    {
        Id = Guid.NewGuid(),
        Name = "TestEmployee6",
        Address = new Address
        {
            AddressLine1 = "Street #6",
            AddressLine2 = "District #6",
            City = "Sample City30",
            Country = "Sample Country22",
        }
    };

    var newEmployee = await client.CreateEmployee(employee);
    Console.WriteLine($"New employee {newEmployee?.Name} has been added");
}
