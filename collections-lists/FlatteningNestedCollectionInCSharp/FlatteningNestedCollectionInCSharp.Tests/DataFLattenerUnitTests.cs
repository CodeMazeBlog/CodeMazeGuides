namespace FlatteningNestedCollection.Tests;

public class DataFlattenerUnitTests
{
    private readonly Department _defaultDepartment;
    private readonly Department _departmentTwoEmployees = new(
        "IT",
        [
            new("John Doe", "john@example.com"),
            new("Jane Doe", "jane@example.com")
        ]
    );

    private readonly List<DepartmentFlattened> _departmentTwoEmployeesFlattened =
    [
        new("IT", "John Doe", "john@example.com"),
        new("IT", "Jane Doe", "jane@example.com")
    ];

    private readonly Department _departmentTwoEmployeesTwoProjects = new(
        "IT",
        [
            new("John Doe", "john@example.com" ),
            new("Jane Doe", "jane@example.com" )
        ],
        [
            new("Product Development", 50000 ),
            new("Research", 20000 )
        ]
    );

    private readonly List<DepartmentFlattenedMultipleCollections> _departmentTwoEmployeesTwoProjectsFlattened =
    [
        new ("IT", "John Doe", "john@example.com", "Product Development",  50000 ),
        new ("IT", "John Doe", "john@example.com", "Research", 20000 ),
        new ("IT", "Jane Doe", "jane@example.com", "Product Development", 50000 ),
        new ("IT", "Jane Doe", "jane@example.com", "Research", 20000 )
    ];

    private readonly Department _departmentTwoEmployeesFourCertificates = new(
        "Engineering",
        [
            new(
                "Charlie",
                "charlie@mail.com",
                [
                    new("MCSD",new DateOnly(2020, 4, 15)),
                    new("PMP",new DateOnly(2022, 3, 1))
                ]
            ),
            new(
                "David",
                "david@mail.com",
                [
                    new("Certified Solutions Architect",new DateOnly(2017, 7, 5)),
                    new("CCNA", new DateOnly(2019, 10, 1)),
                ]
            )
        ]
    );

    private readonly List<DepartmentFlattenedComplex> _departmentTwoEmployeesFourCertificatesFlattened =
    [
        new ("Engineering", "Charlie", "charlie@mail.com", "MCSD" , new DateOnly(2020, 4, 15) ),
        new ("Engineering", "Charlie", "charlie@mail.com", "PMP", new DateOnly(2022, 3, 1) ),
        new ("Engineering", "David", "david@mail.com", "Certified Solutions Architect", new DateOnly(2017, 7, 5) ),
        new ("Engineering", "David", "david@mail.com", "CCNA", new DateOnly(2019, 10, 1) ),
    ];

    [Test]
    public void GivenFlattenWithSelect_WhenNullDepartment_ThenNull()
    {
        var result = DataFlattener.FlattenWithSelect(_defaultDepartment);

        Assert.That(result, Is.Null);
    }

    [Test]
    public void GivenFlattenWithQueryExpression_WhenNullDepartment_ThenEmpty()
    {
        var result = DataFlattener.FlattenWithQueryExpression(_defaultDepartment);

        Assert.That(result, Is.Empty);
    }

    [Test]
    public void GivenFlattenWithSelectMany_WhenNullDepartment_ThenNull()
    {
        var result = DataFlattener.FlattenWithSelectMany(_defaultDepartment);

        Assert.That(result, Is.Null);
    }

    [Test]
    public void GivenFlattenComplexWithSelectMany_WhenNullDepartment_ThenNull()
    {
        var result = DataFlattener.FlattenComplexWithSelectMany(_defaultDepartment);

        Assert.That(result, Is.Null);
    }

    [Test]
    public void GivenFlattenWithSelect_WhenDepartmentTwoEmployees_ThenResultFlattenedObject()
    {
        var result = DataFlattener.FlattenWithSelect(_departmentTwoEmployees);

        Assert.That(result.Count(), Is.EqualTo(2));
        Assert.That(result, Is.EqualTo(_departmentTwoEmployeesFlattened));
    }

    [Test]
    public void GivenFlattenWithQueryExpression_WhenDepartmentTwoEmployees_ThenResultFlattenedObject()
    {
        var result = DataFlattener.FlattenWithQueryExpression(_departmentTwoEmployees);

        Assert.That(result.Count(), Is.EqualTo(2));
        Assert.That(result, Is.EqualTo(_departmentTwoEmployeesFlattened));
    }

    [Test]
    public void GivenFlattenWithSelectMany_WhenDepartmentTwoEmployeesTwoProjects_ThenResultFlattenedObject()
    {
        var result = DataFlattener.FlattenWithSelectMany(_departmentTwoEmployeesTwoProjects);

        Assert.That(result.Count(), Is.EqualTo(4));
        Assert.That(result, Is.EqualTo(_departmentTwoEmployeesTwoProjectsFlattened));
    }

    [Test]
    public void GivenFlattenComplexWithSelectMany_WhenDepartmentTwoEmployeesFourCertificates_ThenResultFlattenedObject()
    {
        var result = DataFlattener.FlattenComplexWithSelectMany(_departmentTwoEmployeesFourCertificates);

        Assert.That(result.Count(), Is.EqualTo(4));
        Assert.That(result, Is.EqualTo(_departmentTwoEmployeesFourCertificatesFlattened));
    }
}