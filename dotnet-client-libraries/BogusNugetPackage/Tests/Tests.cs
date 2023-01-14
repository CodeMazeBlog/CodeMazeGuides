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
    public void WhenGettingSingleEmployee_ThenEmailContainsLastName()
    {
        DataGenerator.InitBogusData();

        var employee = DataGenerator.Employees.First();

        Assert.Contains(employee.LastName, employee.Email);
    }
}
