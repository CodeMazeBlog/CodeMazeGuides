using SystemDynamicLinqCoreLibrary;

Console.WriteLine("Application Started");

var testData = new TestData();

Console.WriteLine();
Console.WriteLine($"{"Name",-20}Department");
Console.WriteLine(new string('=', 47));
foreach (var employee in testData.SelectEmployees())
{
    Console.WriteLine($"{(string)employee.Name,-20}{(string)employee.Department}");
}

Console.WriteLine();
foreach (var employee in testData.SortEmployeesByMultipleProperties())
{
    Console.WriteLine($"Name: {employee.Name}, Dept: {employee.Department}");
}

Console.WriteLine();
foreach (var employee in testData.CreateDynamicLambdaExpressions("IT", 18))
{
    Console.WriteLine($"Name: {employee.Name}, Age: {employee.Age}");
}
