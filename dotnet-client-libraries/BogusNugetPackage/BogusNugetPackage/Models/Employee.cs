using BogusNugetPackage.Enums;
using System.Text.Json;

namespace BogusNugetPackage.Models;
public sealed class Employee 
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Address { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string AboutMe { get; set; } = default!;
    public int YearsOld { get; set; }
    public Personality Personality { get; set; }
    public List<Vehicle> Vehicles { get; set; } = default!;

    public override string ToString()
    {
        return JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
    }
}
