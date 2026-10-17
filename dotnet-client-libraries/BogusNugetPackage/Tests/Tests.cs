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
    public void WhenGettingSingleEmployee_ThenEmailStartsWithFirstName()
    {
        DataGenerator.InitBogusData();

        var employee = DataGenerator.Employees.First();

        Assert.StartsWith(employee.FirstName, employee.Email);
    }

    [Fact]
    public void WhenGeneratingWithTheSameSeed_ThenVehiclesAreEqual()
    {
        var first = DataGenerator.GenerateRepeatableVehicles(1338);
        var second = DataGenerator.GenerateRepeatableVehicles(1338);

        Assert.Equal(first.Select(v => v.ToString()), second.Select(v => v.ToString()));
    }
}
