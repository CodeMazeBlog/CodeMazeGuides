using FlatteningNestedCollectionInCSharp;
using FlatteningNestedCollectionInCSharp.Models;

var department = new Department
{
    Name = "Human Resources",
    Employees =
    [
        new() { Name = "Alice", Email = "alice@mail.com" },
        new() { Name = "Bob", Email = "bob@mail.com" }
    ]
};
Console.WriteLine("FlattenWithSelect method:");
foreach (var flattenedObject in DataFlattener.FlattenWithSelect(department))
{
    Console.WriteLine(flattenedObject);
}

Console.WriteLine("FlattenWithQueryExpression method:");
foreach (var flattenedObject in DataFlattener.FlattenWithQueryExpression(department))
{
    Console.WriteLine(flattenedObject);
}

department = new Department
{
    Name = "Engineering",
    Employees =
    [
        new() { Name = "Charlie", Email = "charlie@mail.com" },
        new() { Name = "David", Email = "david@mail.com" }
    ],
    Projects =
    [
        new() { Title = "Product Development", Budget = 50000 },
        new() { Title = "Research", Budget = 20000 }
    ]
};

Console.WriteLine("FlattenWithSelectMany method:");
foreach (var flattenedObject in DataFlattener.FlattenWithSelectMany(department))
{
    Console.WriteLine(flattenedObject);
}

department = new Department
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

Console.WriteLine("FlattenComplexWithSelectMany method:");
foreach (var flattenedObject in DataFlattener.FlattenComplexWithSelectMany(department))
{
    Console.WriteLine(flattenedObject);
}