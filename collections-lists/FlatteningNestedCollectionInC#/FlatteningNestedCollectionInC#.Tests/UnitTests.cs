namespace FlatteningNestedCollection.Tests;

public class UnitTests
{
    private readonly Department _defaultDepartment;
    private readonly Department _departmentTwoEmployees = new()
    {
        DepartmentName = "IT",
        Employees = new List<Employee>
            {
                new() { EmployeeName = "John Doe", EmployeeEmail = "john@example.com" },
                new() { EmployeeName = "Jane Doe", EmployeeEmail = "jane@example.com" }
            }
    };

    private readonly Department _departmentTwoEmployeesTwoProjects = new Department
    {
        DepartmentName = "IT",
        Employees = new List<Employee>
        {
            new() { EmployeeName = "John Doe", EmployeeEmail = "john@example.com" },
            new() { EmployeeName = "Jane Doe", EmployeeEmail = "jane@example.com" }
        },
        Projects = new List<Project>
        {
            new() { ProjectTitle = "Product Development", Budget = 50000 },
            new() { ProjectTitle = "Research", Budget = 20000 }
        }
    };

    private readonly Department _departmentTwoEmployeesFourCertificates = new()
    {
        DepartmentName = "Engineering",
        Employees = new List<Employee>
        {
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
        }
    };

    [SetUp]
    public void Setup()
    {

    }

    [Test]
    public void GivenFlattenWithSelect_WhenNullDepartment_ThenNull()
    {
        var result = Methods.FlattenWithSelect(_defaultDepartment);

        Assert.That(result, Is.Null);
    }

    [Test]
    public void GivenFlattenWithQueryExpression_WhenNullDepartment_ThenEmpty()
    {
        var result = Methods.FlattenWithQueryExpression(_defaultDepartment);

        Assert.That(result, Is.Empty);
    }

    [Test]
    public void GivenFlattenWithSelectMany_WhenNullDepartment_ThenNull()
    {
        var result = Methods.FlattenWithSelectMany(_defaultDepartment);

        Assert.That(result, Is.Null);
    }

    [Test]
    public void GivenFlattenComplexWithSelectMany_WhenNullDepartment_ThenNull()
    {
        var result = Methods.FlattenComplexWithSelectMany(_defaultDepartment);

        Assert.That(result, Is.Null);
    }

    [Test]
    public void GivenFlattenWithSelect_WhenDepartmentTwoEmployees_ThenTwoResults()
    {
        var result = Methods.FlattenWithSelect(_departmentTwoEmployees);

        Assert.That(result.Count(), Is.EqualTo(2));
    }

    [Test]
    public void GivenFlattenWithQueryExpression_WhenDepartmentTwoEmployees_ThenTwoResults()
    {
        var result = Methods.FlattenWithQueryExpression(_departmentTwoEmployees);

        Assert.That(result.Count(), Is.EqualTo(2));
    }

    [Test]
    public void GivenFlattenWithQueryExpression_WhenDepartmentTwoEmployeesTwoProjects_ThenFourResults()
    {
        var result = Methods.FlattenWithSelectMany(_departmentTwoEmployeesTwoProjects);

        Assert.That(result.Count(), Is.EqualTo(4));
    }

    [Test]
    public void GivenFlattenComplexWithSelectMany_WhenDepartmentTwoEmployeesFourCertificates_ThenTwoResults()
    {
        var result = Methods.FlattenComplexWithSelectMany(_departmentTwoEmployeesFourCertificates);

        Assert.That(result.Count(), Is.EqualTo(4));
    }
}