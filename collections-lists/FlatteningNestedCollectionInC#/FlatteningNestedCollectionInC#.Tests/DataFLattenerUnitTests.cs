using Newtonsoft.Json;

namespace FlatteningNestedCollection.Tests;

public class DataFLattenerUnitTests
{
    private readonly Department _defaultDepartment;
    private readonly Department _departmentTwoEmployees = new()
    {
        DepartmentName = "IT",
        Employees =
            [
                new() { EmployeeName = "John Doe", EmployeeEmail = "john@example.com" },
                new() { EmployeeName = "Jane Doe", EmployeeEmail = "jane@example.com" }
            ]
    };

    private readonly object[] _departmentTwoEmployeesFlattened = new[]
    {
        new { DepartmentName = "IT", EmployeeName = "John Doe", EmployeeEmail = "john@example.com" },
        new { DepartmentName = "IT", EmployeeName = "Jane Doe", EmployeeEmail = "jane@example.com" }
    };

    private readonly Department _departmentTwoEmployeesTwoProjects = new()
    {
        DepartmentName = "IT",
        Employees =
        [
            new() { EmployeeName = "John Doe", EmployeeEmail = "john@example.com" },
            new() { EmployeeName = "Jane Doe", EmployeeEmail = "jane@example.com" }
        ],
        Projects =
        [
            new() { ProjectTitle = "Product Development", Budget = 50000 },
            new() { ProjectTitle = "Research", Budget = 20000 }
        ]
    };

    private readonly object[] _departmentTwoEmployeesTwoProjectsFlattened = new[]
    {
        new { DepartmentName = "IT", EmployeeName = "John Doe", EmployeeEmail = "john@example.com", ProjectTitle = "Product Development", Budget = 50000 },
        new { DepartmentName = "IT", EmployeeName = "John Doe", EmployeeEmail = "john@example.com", ProjectTitle = "Research", Budget = 20000 },
        new { DepartmentName = "IT", EmployeeName = "Jane Doe", EmployeeEmail = "jane@example.com", ProjectTitle = "Product Development", Budget = 50000 },
        new { DepartmentName = "IT", EmployeeName = "Jane Doe", EmployeeEmail = "jane@example.com", ProjectTitle = "Research", Budget = 20000 },
    };

    private readonly Department _departmentTwoEmployeesFourCertificates = new()
    {
        DepartmentName = "Engineering",
        Employees =
        [
            new() {
                EmployeeName = "Charlie",
                EmployeeEmail = "charlie@mail.com",
                Certifications = [
                    new()
                    {
                        Title = "MCSD",
                        IssueDate = new DateOnly(2020, 4, 15)
                    },
                    new()
                    {
                        Title = "PMP",
                        IssueDate = new DateOnly(2022, 3, 1)
                    }
                 ]
            },
            new() {
                EmployeeName = "David",
                EmployeeEmail = "david@mail.com" ,
                Certifications = [
                    new()
                    {
                        Title = "Certified Solutions Architect",
                        IssueDate = new DateOnly(2017, 7, 5)
                    },
                    new()
                    {
                        Title = "CCNA",
                        IssueDate = new DateOnly(2019, 10, 1)
                    }
                 ]
            }
        ]
    };

    private readonly object[] _departmentTwoEmployeesFourCertificatesFlattened = new[]
    {
        new { DepartmentName = "Engineering", EmployeeName = "Charlie", EmployeeEmail = "charlie@mail.com", Title = "MCSD" , IssueDate = new DateOnly(2020, 4, 15) },
        new { DepartmentName = "Engineering", EmployeeName = "Charlie", EmployeeEmail = "charlie@mail.com", Title = "PMP", IssueDate = new DateOnly(2022, 3, 1) },
        new { DepartmentName = "Engineering", EmployeeName = "David", EmployeeEmail = "david@mail.com", Title = "Certified Solutions Architect", IssueDate = new DateOnly(2017, 7, 5) },
        new { DepartmentName = "Engineering", EmployeeName = "David", EmployeeEmail = "david@mail.com", Title = "CCNA", IssueDate = new DateOnly(2019, 10, 1) },
    };

    [Test]
    public void GivenFlattenWithSelect_WhenNullDepartment_ThenNull()
    {
        var result = DataFlattenerMethods.FlattenWithSelect(_defaultDepartment);

        Assert.That(result, Is.Null);
    }

    [Test]
    public void GivenFlattenWithQueryExpression_WhenNullDepartment_ThenEmpty()
    {
        var result = DataFlattenerMethods.FlattenWithQueryExpression(_defaultDepartment);

        Assert.That(result, Is.Empty);
    }

    [Test]
    public void GivenFlattenWithSelectMany_WhenNullDepartment_ThenNull()
    {
        var result = DataFlattenerMethods.FlattenWithSelectMany(_defaultDepartment);

        Assert.That(result, Is.Null);
    }

    [Test]
    public void GivenFlattenComplexWithSelectMany_WhenNullDepartment_ThenNull()
    {
        var result = DataFlattenerMethods.FlattenComplexWithSelectMany(_defaultDepartment);

        Assert.That(result, Is.Null);
    }

    [Test]
    public void GivenFlattenWithSelect_WhenDepartmentTwoEmployees_ThenTwoResults()
    {
        var result = DataFlattenerMethods.FlattenWithSelect(_departmentTwoEmployees);

        Assert.That(result.Count(), Is.EqualTo(2));
    }

    [Test]
    public void GivenFlattenWithSelect_WhenDepartmentTwoEmployees_ThenResultFlattenedObject()
    {
        var result = DataFlattenerMethods.FlattenWithSelect(_departmentTwoEmployees);

        Assert.That(JsonConvert.SerializeObject(result), Is.EqualTo(JsonConvert.SerializeObject(_departmentTwoEmployeesFlattened)));
    }

    [Test]
    public void GivenFlattenWithQueryExpression_WhenDepartmentTwoEmployees_ThenTwoResults()
    {
        var result = DataFlattenerMethods.FlattenWithQueryExpression(_departmentTwoEmployees);

        Assert.That(result.Count(), Is.EqualTo(2));
    }

    [Test]
    public void GivenFlattenWithQueryExpression_WhenDepartmentTwoEmployees_ThenResultFlattenedObject()
    {
        var result = DataFlattenerMethods.FlattenWithQueryExpression(_departmentTwoEmployees);

        Assert.That(JsonConvert.SerializeObject(result), Is.EqualTo(JsonConvert.SerializeObject(_departmentTwoEmployeesFlattened)));
    }

    [Test]
    public void GivenFlattenWithSelectMany_WhenDepartmentTwoEmployeesTwoProjects_ThenFourResults()
    {
        var result = DataFlattenerMethods.FlattenWithSelectMany(_departmentTwoEmployeesTwoProjects);

        Assert.That(result.Count(), Is.EqualTo(4));
    }

    [Test]
    public void GivenFlattenWithSelectMany_WhenDepartmentTwoEmployeesTwoProjects_ThenResultFlattenedObject()
    {
        var result = DataFlattenerMethods.FlattenWithSelectMany(_departmentTwoEmployeesTwoProjects);

        Assert.That(JsonConvert.SerializeObject(result), Is.EqualTo(JsonConvert.SerializeObject(_departmentTwoEmployeesTwoProjectsFlattened)));
    }

    [Test]
    public void GivenFlattenComplexWithSelectMany_WhenDepartmentTwoEmployeesFourCertificates_ThenTwoResults()
    {
        var result = DataFlattenerMethods.FlattenComplexWithSelectMany(_departmentTwoEmployeesFourCertificates);

        Assert.That(result.Count(), Is.EqualTo(4));
    }

    [Test]
    public void GivenFlattenComplexWithSelectMany_WhenDepartmentTwoEmployeesFourCertificates_ThenResultFlattenedObject()
    {
        var result = DataFlattenerMethods.FlattenComplexWithSelectMany(_departmentTwoEmployeesFourCertificates);

        Assert.That(JsonConvert.SerializeObject(result), Is.EqualTo(JsonConvert.SerializeObject(_departmentTwoEmployeesFourCertificatesFlattened)));
    }
}