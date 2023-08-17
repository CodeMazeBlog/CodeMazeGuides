namespace TupleAliasInCSharp;

using EmployeeFinanaceDetails = (int Id, string FName, string LName, double salary);

public class TupleAlias
{
    public static void PrintTupleValues()
    {
        //ACCESS TUPLE WITH GLOBAL USING DIRECTIVE
        EmployeeDetails employee = (1, "John","Doe", 116000);
        Console.WriteLine($"Employee ID: {employee.Id}, First Name: {employee.firstName}, Last Name: {employee.lastName}, Salary: {employee.salary}");
        Console.WriteLine();

        //ACCESS TUPLE WITH USING DIRECTIVE
        EmployeeFinanaceDetails finanaceDetails = (1, "John", "Doe", 116000.25);
        Console.WriteLine($"Employee ID: {finanaceDetails.Id}, First Name: {finanaceDetails.FName}, Last Name: {finanaceDetails.LName}, Salary: {finanaceDetails.salary}");
        Console.WriteLine();

        //DECONSTRUCT TUPLE USING ALIAS NAME
        Console.WriteLine("Deconstruct tuple without using 'var' keyword");
        (int id, string fn, string ln, int salary) = employee;
        Console.WriteLine($"Employee ID: {id}, First Name: {fn}, Last Name: {ln}, Salary: {salary}");

        //DECONSTRUCT TUPLE USING 'var' KEYWORD
        Console.WriteLine("Deconstruct tuple using 'var' keyword");
        var (id1, fn1, ln1, salary1) = employee;
        Console.WriteLine($"Employee ID: {id1}, First Name: {fn1}, Last Name: {ln1}, Salary: {salary1}");

        // TUPLE ASSIGNMENT - the field names need not match, only the types and the arity need to match
        Console.WriteLine("\n Tuple assignment using 'var' keyword. We are assigning values from EmployeeDetails to EmployeeFinanceDetails tuple.");
        finanaceDetails = employee;
        Console.WriteLine($"Employee ID: {finanaceDetails.Id}, First Name: {finanaceDetails.FName}, Last Name: {finanaceDetails.LName}, Salary: {finanaceDetails.salary}");

        //This will generate error as (int,string, string, double) cannot to converted to (int, string, string, int). Use explicit conversion
        Console.WriteLine("\nAssigning values from EmployeeFinanceDetails to EmployeeDetails tuple will generate error as (int,string, string, double) cannot to converted to (int, string, string, int).\nUse explicit conversion.");
        employee = ((int Id, string firstName, string lastName, int salary))finanaceDetails;
        Console.WriteLine($"Employee ID: {employee.Id}, First Name: {employee.firstName}, Last Name: {employee.lastName}, Salary: {employee.salary}");        
    }
}
