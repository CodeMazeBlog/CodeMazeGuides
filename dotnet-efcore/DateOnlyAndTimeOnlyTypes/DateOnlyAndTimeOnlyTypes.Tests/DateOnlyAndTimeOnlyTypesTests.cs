using System;
using Xunit;

namespace DateOnlyAndTimeOnlyTypes.Tests;

public class DateOnlyAndTimeOnlyTypesTest
{
    private readonly AppDbContext _context;

    public DateOnlyAndTimeOnlyTypesTest()
    {
        _context = new AppDbContext();
        _context.Database.EnsureDeleted();
        _context.Database.EnsureCreated();
    }

    [Fact]
    public void GivenDbContext_WhenHavingProperConverters_ThenRightlyStoresDateOnlyTimeOnlyValues()
    {
        var employee = new Employee
        {
            Name = "John Doe",
            BirthDate = new DateOnly(2023, 5, 9),
            WorkStartTime = new TimeOnly(8, 30),
            WorkEndTime = new TimeOnly(4, 30)
        };

        _context.Employees.Add(employee);
        _context.SaveChanges();

        var storedEmployee = _context.Employees.Find(employee.Id);

        Assert.NotNull(storedEmployee);
        Assert.Equal(employee.BirthDate, storedEmployee!.BirthDate);
        Assert.Equal(employee.WorkStartTime, storedEmployee.WorkStartTime);
        Assert.Equal(employee.WorkEndTime, storedEmployee.WorkEndTime);
    }
}