namespace TupleAliasInCSharp.GlobalAliasUsing;

public static class GlobalAliasUsing
{
    public static void PrintTupleWithGlobalUsing()
    {
        Console.WriteLine("Using global tuple alias from different namespace");
        EmployeeDetails employee = (2, "Sue", "Storm", 216000);
        Console.WriteLine($"Employee ID: {employee.id}, First Name: {employee.firstName}, Last Name: {employee.lastName}, Salary: {employee.salary}");
    }
}