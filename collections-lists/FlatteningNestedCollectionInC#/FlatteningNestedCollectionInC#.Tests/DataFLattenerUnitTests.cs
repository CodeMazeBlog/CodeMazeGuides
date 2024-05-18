using FlatteningNestedCollectionInCSharp.Models;
using Newtonsoft.Json;

namespace FlatteningNestedCollection.Tests;

public class DataFLattenerUnitTests
{
    private readonly Department _defaultDepartment;
    private readonly Department _departmentTwoEmployees = new()
    {
        Name = "IT",
        Employees =
            [
                new() { Name = "John Doe", Email = "john@example.com" },
                new() { Name = "Jane Doe", Email = "jane@example.com" }
            ]
    };

    private readonly List<DepartmentFlattened> _departmentTwoEmployeesFlattened =
    [
        new() { DepartmentName = "IT", EmployeeName = "John Doe", EmployeeEmail = "john@example.com" },
        new() { DepartmentName = "IT", EmployeeName = "Jane Doe", EmployeeEmail = "jane@example.com" }
    ];

    private readonly Department _departmentTwoEmployeesTwoProjects = new()
    {
        Name = "IT",
        Employees =
        [
            new() { Name = "John Doe", Email = "john@example.com" },
            new() { Name = "Jane Doe", Email = "jane@example.com" }
        ],
        Projects =
        [
            new() { Title = "Product Development", Budget = 50000 },
            new() { Title = "Research", Budget = 20000 }
        ]
    };

    private readonly List<DepartmentFlattenedMultipleCollections> _departmentTwoEmployeesTwoProjectsFlattened =
    [
        new () { DepartmentName = "IT", EmployeeName = "John Doe", EmployeeEmail = "john@example.com", ProjectTitle = "Product Development", ProjectBudget = 50000 },
        new () { DepartmentName = "IT", EmployeeName = "John Doe", EmployeeEmail = "john@example.com", ProjectTitle = "Research", ProjectBudget = 20000 },
        new () { DepartmentName = "IT", EmployeeName = "Jane Doe", EmployeeEmail = "jane@example.com", ProjectTitle = "Product Development", ProjectBudget = 50000 },
        new () { DepartmentName = "IT", EmployeeName = "Jane Doe", EmployeeEmail = "jane@example.com", ProjectTitle = "Research", ProjectBudget = 20000 },
    ];

    private readonly Department _departmentTwoEmployeesFourCertificates = new()
    {
        Name = "Engineering",
        Employees =
        [
            new() {
                Name = "Charlie",
                Email = "charlie@mail.com",
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
                Name = "David",
                Email = "david@mail.com" ,
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

    private readonly List<DepartmentFlattenedComplex> _departmentTwoEmployeesFourCertificatesFlattened =
    [
        new () { DepartmentName = "Engineering", EmployeeName = "Charlie", EmployeeEmail = "charlie@mail.com", CertificationTitle = "MCSD" , CertificationIssueDate = new DateOnly(2020, 4, 15) },
        new () { DepartmentName = "Engineering", EmployeeName = "Charlie", EmployeeEmail = "charlie@mail.com", CertificationTitle = "PMP", CertificationIssueDate = new DateOnly(2022, 3, 1) },
        new () { DepartmentName = "Engineering", EmployeeName = "David", EmployeeEmail = "david@mail.com", CertificationTitle = "Certified Solutions Architect", CertificationIssueDate = new DateOnly(2017, 7, 5) },
        new () { DepartmentName = "Engineering", EmployeeName = "David", EmployeeEmail = "david@mail.com", CertificationTitle = "CCNA", CertificationIssueDate = new DateOnly(2019, 10, 1) },
    ];

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

        Assert.That(result, Is.EqualTo(_departmentTwoEmployeesFlattened));
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

        Assert.That(result, Is.EqualTo(_departmentTwoEmployeesFlattened));
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

        Assert.That(result, Is.EqualTo(_departmentTwoEmployeesTwoProjectsFlattened));
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

        Assert.That(result, Is.EqualTo(_departmentTwoEmployeesFourCertificatesFlattened));
    }
}