using Bogus;
using BogusNugetPackage.Database;
using BogusNugetPackage.Enums;
using BogusNugetPackage.Models;
using Microsoft.EntityFrameworkCore;

namespace BogusNugetPackage;
public static class DataGenerator
{
    public static readonly List<Employee> Employees = new();
    public static readonly List<Vehicle> Vehicles = new();

    public static Employee GetSingleEmployee()
    {
        return Employees.First();
    }

    public static List<Employee> GetListOfEmployees()
    {
        return Employees;
    }

    public static List<Employee> GetSeededEmployeesFromDb()
    {
        using var employeeDbContext = new EmployeeContext();

        var dbEmployeesWithVehicles = employeeDbContext.Employees
           .Include(e => e.Vehicles)
           .ToList();

        return dbEmployeesWithVehicles;
    }

    public static void InitBogusEmployeeData()
    {
        var employeeGenerator = new Faker<Employee>()
            .RuleFor(e => e.Id, _ => Guid.NewGuid())
            .RuleFor(e => e.FirstName, f => f.Name.FirstName())
            .RuleFor(e => e.LastName, f => f.Name.LastName())
            .RuleFor(e => e.Address, f => f.Address.FullAddress())
            .RuleFor(e => e.Email, (f, e) => f.Internet.Email(e.FirstName, e.LastName))
            .RuleFor(e => e.AboutMe, f => f.Lorem.Paragraph(1))
            .RuleFor(e => e.YearsOld, f => f.Random.Int(18, 90))
            .RuleFor(e => e.Personality, f => f.PickRandom<Personality>())
            .RuleFor(e => e.Vehicles, (_, e) => 
            {
                InitBogusVehicleData(e.Id);
                return null!;
            });

        var generatedEmployees = employeeGenerator.Generate(5);
        Employees.AddRange(generatedEmployees);
    }

    private static void InitBogusVehicleData(Guid employeeId)
    {
        var vehicleGenerator = new Faker<Vehicle>()
            .RuleFor(v => v.Id, _ => Guid.NewGuid())
            .RuleFor(v => v.EmployeeId, _ => employeeId)
            .RuleFor(v => v.Manufacturer, f => f.Vehicle.Manufacturer())
            .RuleFor(v => v.Fuel, f => f.Vehicle.Fuel());

        var generatedVehicles = vehicleGenerator.Generate(3);
        Vehicles.AddRange(generatedVehicles);
    }
}
