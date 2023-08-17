namespace TupleAliasInCSharp.GlobalAlias;

internal class GlobalAlias
{
    //ACCESS TUPLE WITH GLOBAL USING DIRECTIVE
    internal static void PrintTupleWithGlobalUsing()
    {
        Console.WriteLine("\nUsing global tuple alias from different namespace");
        EmployeeDetails employee = (2, "Sue", "Storm", 216000);
        Console.WriteLine($"\nEmployee ID: {employee.Id}, First Name: {employee.firstName}, Last Name: {employee.lastName}, Salary: {employee.salary}");
    }
}