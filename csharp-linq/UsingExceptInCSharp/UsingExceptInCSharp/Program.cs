using UsingExceptInCSharp;

var examples = new ExceptMethodExamples();

Console.WriteLine(string.Join(", ", examples.GetDistinctDifference()));
Console.WriteLine(examples.GetEmployeesNotInSales().Count);
Console.WriteLine(examples.GetEmployeesNotInSalesFromCopies().Count);
Console.WriteLine(examples.GetEmployeesNotInSalesUsingComparer().Count);
Console.WriteLine(string.Join(", ", examples.GetEmployeeRecordsNotInSales().Select(e => e.Name)));
Console.WriteLine(string.Join(", ", examples.GetEmployeesNotInITIgnoreCase()));
Console.WriteLine(string.Join(", ", examples.GetEmployeesNotInITByID().Select(e => e.Name)));
