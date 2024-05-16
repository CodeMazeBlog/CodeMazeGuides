using FlatteningNestedCollection;
using FlatteningNestedCollection.Models;

var department = new Department
{
    DepartmentName = "Human Resources",
    Employees = new List<Employee>
    {
        new() { EmployeeName = "Alice", EmployeeEmail = "alice@mail.com" },
        new() { EmployeeName = "Bob", EmployeeEmail = "bob@mail.com" }
    }
};
Console.WriteLine("FlattenWithSelect method:");
foreach (var flattenedObject in DataFlattenerMethods.FlattenWithSelect(department))
{
    Console.WriteLine(flattenedObject);
}

Console.WriteLine("FlattenWithQueryExpression method:");
foreach (var flattenedObject in DataFlattenerMethods.FlattenWithQueryExpression(department))
{
    Console.WriteLine(flattenedObject);
}

department = new Department
{
    DepartmentName = "Engineering",
    Employees = new List<Employee>
    {
        new() { EmployeeName = "Charlie", EmployeeEmail = "charlie@mail.com" },
        new() { EmployeeName = "David", EmployeeEmail = "david@mail.com" }
    },
    Projects = new List<Project>
    {
        new() { ProjectTitle = "Product Development", Budget = 50000 },
        new() { ProjectTitle = "Research", Budget = 20000 }
    }
};

Console.WriteLine("FlattenWithSelectMany method:");
foreach (var flattenedObject in DataFlattenerMethods.FlattenWithSelectMany(department))
{
    Console.WriteLine(flattenedObject);
}

department = new Department
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

Console.WriteLine("FlattenComplexWithSelectMany method:");
foreach (var flattenedObject in DataFlattenerMethods.FlattenComplexWithSelectMany(department))
{
    Console.WriteLine(flattenedObject);
}