using FlatteningNestedCollectionInCSharp;
using FlatteningNestedCollectionInCSharp.Models;

var department = new Department(
    "Human Resources", 
    [
        new("Alice", "alice@mail.com"), 
        new("Bob", "bob@mail.com")
    ]
);

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

department = new Department(
    "Engineering",
    [
        new("Charlie", "charlie@mail.com"), 
        new("David", "david@mail.com")
    ],
    [
        new("Product Development", 50000), 
        new("Research", 20000)
    ]
);

Console.WriteLine("FlattenWithSelectMany method:");
foreach (var flattenedObject in DataFlattener.FlattenWithSelectMany(department))
{
    Console.WriteLine(flattenedObject);
}

department = new Department(
    "Engineering",
    [
        new(
            "Charlie",
            "charlie@mail.com",
            [
                new("MCSD", new DateOnly(2020, 4, 15)),
                new("PMP", new DateOnly(2022, 3, 1))
            ]
        ),
        new(
            "Bob",
            "bob@mail.com",
            [
                new("Certified Solutions Architect", new DateOnly(2017, 7, 5)),
                new("CCNA", new DateOnly(2019, 10, 1))
            ]
        )
    ]
);

Console.WriteLine("FlattenComplexWithSelectMany method:");
foreach (var flattenedObject in DataFlattener.FlattenComplexWithSelectMany(department))
{
    Console.WriteLine(flattenedObject);
}