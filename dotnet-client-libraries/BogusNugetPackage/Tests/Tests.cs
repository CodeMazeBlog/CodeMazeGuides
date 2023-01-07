using BogusNugetPackage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests;
public class Tests
{
    [Fact]
    public void WhenGettingSingleEmployee_ThenObjectIsNotNull()
    {
        DataGenerator.InitBogusData();

        var employee = DataGenerator.Employees.First();

        Assert.NotNull(employee);
    }

    [Fact]
    public void WhenGettingSingleVehicle_ThenObjectIsNotNull()
    {
        DataGenerator.InitBogusData();

        var vehicle = DataGenerator.Vehicles.First();

        Assert.NotNull(vehicle);
    }

    [Fact]
    public void WhenGettingSingleDbEmployee_ThenObjectItHasCorrectNumberOfVehicles()
    {
        DataGenerator.InitBogusData();

        var employee = DataGenerator.GetSeededEmployeesFromDb().First();

        Assert.Equal(DataGenerator.NumberOfVehiclesPerEmployee, employee.Vehicles.Count);
    }

    [Fact]
    public void WhenGettingAllEmployeesFromDb_ThenNumberOfVehiclesIsCorrect()
    {
        DataGenerator.InitBogusData();
        var expectedTotalNumberOfVehicles = DataGenerator.NumberOfEmployees * DataGenerator.NumberOfVehiclesPerEmployee;

        var employees = DataGenerator.GetSeededEmployeesFromDb();

        Assert.Equal(expectedTotalNumberOfVehicles, employees.Sum(x => x.Vehicles.Count));
    }

    [Fact]
    public void WhenGettingSingleEmployee_ThenEmailIncludesLastName()
    {
        DataGenerator.InitBogusData();

        var employee = DataGenerator.Employees.First();

        Assert.Contains(employee.LastName, employee.Email);
    }
}
