namespace TupleAliasInCSharp;

using employeeFinanceDetails = (int id, string name, string familyName, double salary);

public class TupleAlias
{
    public static void PrintTupleValues()
    {
        Console.WriteLine("\nAccess tuple with 'global using' directive:");
        employeeDetails employee = (1, "John", "Doe", 116000.25f);
        Console.WriteLine($"Employee ID: {employee.id}, First Name: {employee.firstName}, Last Name: {employee.lastName}, Salary: {employee.salary}");

        Console.WriteLine("\nAccess tuple with 'using' directive:");
        employeeFinanceDetails financeDetails = (1, "John", "Doe", 116000.25);
        Console.WriteLine($"Employee ID: {financeDetails.id}, First Name: {financeDetails.name}, Last Name: {financeDetails.familyName}, Salary: {financeDetails.salary}");

        Console.WriteLine("\nDeconstruct tuple without using 'var' keyword");
        (int id, string fn, string ln, float salary) = employee;
        Console.WriteLine($"Employee ID: {id}, First Name: {fn}, Last Name: {ln}, Salary: {salary}");

        Console.WriteLine("\nDeconstruct tuple using 'var' keyword");
        var (id1, fn1, ln1, salary1) = employee;
        Console.WriteLine($"Employee ID: {id1}, First Name: {fn1}, Last Name: {ln1}, Salary: {salary1}");

        Console.WriteLine("\nTuple assignment using 'var' keyword. We are assigning values from EmployeeDetails to EmployeeFinanceDetails tuple.");
        financeDetails = employee;
        Console.WriteLine($"Employee ID: {financeDetails.id}, First Name: {financeDetails.name}, Last Name: {financeDetails.familyName}, Salary: {financeDetails.salary}");

        Console.WriteLine("\nAssigning values from EmployeeFinanceDetails to EmployeeDetails tuple will generate error as (int,string,string,double) cannot to converted to (int,string,string,int). Use explicit conversion.");
        employee = ((int id, string firstName, string lastName, float salary))financeDetails;        
        Console.WriteLine($"Employee ID: {employee.id}, First Name: {employee.firstName}, Last Name: {employee.lastName}, Salary: {employee.salary}");

        string employeeFullName = employee.firstName + " " + employee.lastName;
        Console.WriteLine($"Employee Full Name: {employeeFullName}");  
    }        
}