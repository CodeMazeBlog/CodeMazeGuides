namespace TupleAliasInCSharp;

using EmployeeFinanceDetails = (int id, string name, string familyName, double salary);

public static class TupleAlias
{
    public static void PrintTupleValues()
    {
        Console.WriteLine("\nAccess tuple with 'global using' directive:");
        EmployeeDetails employee = (1, "John", "Doe", 116000.25f);
        Console.WriteLine($"Employee ID: {employee.id}, First Name: {employee.firstName}, Last Name: {employee.lastName}, Salary: {employee.salary}");

        Console.WriteLine("\nAccess tuple with 'using' directive:");
        EmployeeFinanceDetails financeDetails = (1, "John", "Doe", 116000.25);
        Console.WriteLine($"Employee ID: {financeDetails.id}, First Name: {financeDetails.name}, Last Name: {financeDetails.familyName}, Salary: {financeDetails.salary}");

        Console.WriteLine("\nDeconstruct tuple without using 'var' keyword");
        (int id, var fName, string lName, float sal) = employee;
        Console.WriteLine($"Employee ID: {id}, First Name: {fName}, Last Name: {lName}, Salary: {sal}");

        Console.WriteLine("\nDeconstruct tuple using 'var' keyword");
        var (id1, fName1, lName1, sal1) = employee;
        Console.WriteLine($"Employee ID: {id1}, First Name: {fName1}, Last Name: {lName1}, Salary: {sal1}");

        Console.WriteLine("\nTuple assignment using 'var' keyword. We are assigning values from EmployeeDetails to EmployeeFinanceDetails tuple.");
        financeDetails = employee;
        Console.WriteLine($"Employee ID: {financeDetails.id}, First Name: {financeDetails.name}, Last Name: {financeDetails.familyName}, Salary: {financeDetails.salary}");

        Console.WriteLine("\nAssigning values from EmployeeFinanceDetails to EmployeeDetails tuple will generate error as (int,string,string,double) cannot to converted to (int,string,string,int). Use explicit conversion.");
        employee = ((int id, string firstName, string lastName, float salary))financeDetails;
        Console.WriteLine($"Employee ID: {employee.id}, First Name: {employee.firstName}, Last Name: {employee.lastName}, Salary: {employee.salary}");

        var employeeFullName = $"Employee Full Name: {employee.firstName} {employee.lastName}";
        Console.WriteLine(employeeFullName);
    }
}

/*
* BELOW CODE IS ADDED TO VERIFY THE SCENARIO WHERE A CONCRETE TYPE HAS THE SAME NAME AS THE TUPLE ALIAS (BOTH LOCAL AND GLOBAL).
* UNCOMMENTING THIS WILL CAUSE AN ERROR DUE TO THE NAME CONFLICT 

public static class EmployeeFinanceDetails
{
    public static void Print()
    {
        Console.WriteLine("Concrete class with name similar to Local tuple alias");
    }
}


public static class EmployeeDetails
{
    public static void Print()
    {
        Console.WriteLine("Concrete class with name similar to global tuple alias");
    }
}
*/