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

    public const int NumberOfEmployees = 5;
    public const int NumberOfVehiclesPerEmployee = 2;

    public static List<Employee> GetSeededEmployeesFromDb()
    {
        using var employeeDbContext = new EmployeeContext();

        employeeDbContext.Database.EnsureCreated();

        var dbEmployeesWithVehicles = employeeDbContext.Employees
           .Include(e => e.Vehicles)
           .ToList();

        return dbEmployeesWithVehicles;
    }

    public static void InitBogusData()
    {
        var employeeGenerator = GetEmployeeGenerator();
        var generatedEmployees = employeeGenerator.Generate(NumberOfEmployees);
        Employees.AddRange(generatedEmployees);
        generatedEmployees.ForEach(e => Vehicles.AddRange(GetBogusVehicleData(e.Id)));
    }

    private static List<Vehicle> GetBogusVehicleData(Guid employeeId)
    {
        var vehicleGenerator = GetVehicleGenerator(employeeId);
        var generatedVehicles = vehicleGenerator.Generate(NumberOfVehiclesPerEmployee);

        return generatedVehicles;
    }

    private static Faker<Employee> GetEmployeeGenerator()
    {
        return new Faker<Employee>()
            .RuleFor(e => e.Id, _ => Guid.NewGuid())
            .RuleFor(e => e.FirstName, f => f.Name.FirstName())
            .RuleFor(e => e.LastName, f => f.Name.LastName())
            .RuleFor(e => e.Address, f => f.Address.FullAddress())
            .RuleFor(e => e.Email, (f, e) => f.Internet.Email(e.FirstName, e.LastName))
            .RuleFor(e => e.AboutMe, f => f.Lorem.Paragraph(1))
            .RuleFor(e => e.YearsOld, f => f.Random.Int(18, 90))
            .RuleFor(e => e.Personality, f => f.PickRandom<Personality>());
    }

    private static Faker<Vehicle> GetVehicleGenerator(Guid employeeId)
    {
        return new Faker<Vehicle>()
            .RuleFor(v => v.Id, _ => Guid.NewGuid())
            .RuleFor(v => v.EmployeeId, _ => employeeId)
            .RuleFor(v => v.Manufacturer, f => f.Vehicle.Manufacturer())
            .RuleFor(v => v.Fuel, f => f.Vehicle.Fuel());
    }
}
