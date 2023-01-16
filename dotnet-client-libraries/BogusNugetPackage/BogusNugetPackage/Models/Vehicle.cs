using System.Text.Json;

namespace BogusNugetPackage.Models;
public sealed class Vehicle
{
    public Guid Id { get; set; }
    public Guid EmployeeId { get; set; }
    public string Manufacturer { get; set; } = default!;
    public string Fuel { get; set; } = default!;

    public override string ToString()
    {
        return JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
    }
}
