using SelectVsSelectMany.Tests.Models;

namespace SelectVsSelectMany.Tests;

public class SelectManyTests
{
    private List<Department> _listOfDepartments = new()
    {
        new Department
        {
            Name = "TechSupport",
            Employees = new()
            {
                new Employee { Name = "Thomas", JobPosition = JobPosition.Admin }, 
                new Employee { Name = "Cynthia", JobPosition = JobPosition.Admin }    
            }
        }, 
        new Department
        {
            Name = "Development",
            Employees = new()
            {
                new Employee { Name = "Eric", JobPosition = JobPosition.Developer }, 
                new Employee { Name = "Laura", JobPosition = JobPosition.Developer }, 
                new Employee { Name = "Cedric", JobPosition = JobPosition.Developer }
            }
        },
        new Department
        {
            Name = "BackOffice",
            Employees = new()
            {
                new Employee { Name = "Monica", JobPosition = JobPosition.HumanResources }
            }
        }
    };
    
    [Test]
    public void WhenUsingSelectManyToFlattenTheCollection_ThenCollectionShouldBeFlattened()
    {
        var listOfEmployees = _listOfDepartments.SelectMany(department => department.Employees).ToList();
        
        Assert.That(listOfEmployees.Count, Is.EqualTo(6));
        Assert.That(listOfEmployees[0].Name, Is.EqualTo("Thomas"));
        Assert.That(listOfEmployees[1].Name, Is.EqualTo("Cynthia"));
        Assert.That(listOfEmployees[2].Name, Is.EqualTo("Eric"));
        Assert.That(listOfEmployees[3].Name, Is.EqualTo("Laura"));
        Assert.That(listOfEmployees[4].Name, Is.EqualTo("Cedric"));
        Assert.That(listOfEmployees[5].Name, Is.EqualTo("Monica"));
    }

    [Test]
    public void WhenUsingSelectManyToFlattenTheCollectionAndApplyIndexing_ThenCollectionShouldBeFlattenedWithIndex()
    {
        var emplyeesWithDepartmentCodes = _listOfDepartments.SelectMany((department, index) =>
                department.Employees.Select(employee => $"{employee.Name} - DepartmentCode: {index}"))
            .ToList();
        
        Assert.That(emplyeesWithDepartmentCodes.Count, Is.EqualTo(6));
        Assert.That(emplyeesWithDepartmentCodes[0], Is.EqualTo("Thomas - DepartmentCode: 0"));
        Assert.That(emplyeesWithDepartmentCodes[1], Is.EqualTo("Cynthia - DepartmentCode: 0"));
        Assert.That(emplyeesWithDepartmentCodes[2], Is.EqualTo("Eric - DepartmentCode: 1"));
        Assert.That(emplyeesWithDepartmentCodes[3], Is.EqualTo("Laura - DepartmentCode: 1"));
        Assert.That(emplyeesWithDepartmentCodes[4], Is.EqualTo("Cedric - DepartmentCode: 1"));
        Assert.That(emplyeesWithDepartmentCodes[5], Is.EqualTo("Monica - DepartmentCode: 2"));
    }

    [Test]
    public void WhenUsingSelectManyToFlattenTheCollectionAndSubCollections_ThenCollectionShouldBeFlattened()
    {
        var detailedListOfEmployees = _listOfDepartments.SelectMany(department => 
                department.Employees, (department, employee) => $"{employee.Name} | {department.Name} | {employee.JobPosition}") 
            .ToList();
        
        Assert.That(detailedListOfEmployees.Count, Is.EqualTo(6));
        Assert.That(detailedListOfEmployees[0], Is.EqualTo("Thomas | TechSupport | Admin"));
        Assert.That(detailedListOfEmployees[1], Is.EqualTo("Cynthia | TechSupport | Admin"));
        Assert.That(detailedListOfEmployees[2], Is.EqualTo("Eric | Development | Developer"));
        Assert.That(detailedListOfEmployees[3], Is.EqualTo("Laura | Development | Developer"));
        Assert.That(detailedListOfEmployees[4], Is.EqualTo("Cedric | Development | Developer"));
        Assert.That(detailedListOfEmployees[5], Is.EqualTo("Monica | BackOffice | HumanResources"));
    }
}