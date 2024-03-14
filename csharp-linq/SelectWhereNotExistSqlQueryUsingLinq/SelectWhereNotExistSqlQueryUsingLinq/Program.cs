using Microsoft.EntityFrameworkCore;
using SelectWhereNotExistSqlQueryUsingLinq;

using var context = new EmployeeDbContext();

if (!context.Database.CanConnect())
{
   context.Database.EnsureCreated();
   context.AddSeedData();
}

var unassignedEmployees = QueryExecutor.GetUnassignedEmployeesAnyQuerySyntax(context);
Console.WriteLine(unassignedEmployees.ToQueryString());
PrintEmployeeDetails(unassignedEmployees.ToList());

unassignedEmployees = QueryExecutor.GetUnassignedEmployeesAnyMethodSyntax(context);
Console.WriteLine(unassignedEmployees.ToQueryString());
PrintEmployeeDetails(unassignedEmployees.ToList());

unassignedEmployees = QueryExecutor.GetUnassignedEmployeesJoinQuerySyntax(context);
Console.WriteLine(unassignedEmployees.ToQueryString());
PrintEmployeeDetails(unassignedEmployees.ToList());

unassignedEmployees = QueryExecutor.GetUnassignedEmployeesJoinMethodSyntax(context);
Console.WriteLine(unassignedEmployees.ToQueryString());
PrintEmployeeDetails(unassignedEmployees.ToList());

unassignedEmployees = QueryExecutor.GetUnassignedEmployeesContainsQuerySyntax(context);
Console.WriteLine(unassignedEmployees.ToQueryString());
PrintEmployeeDetails(unassignedEmployees.ToList());

unassignedEmployees = QueryExecutor.GetUnassignedEmployeesContainsMethodSyntax(context);
Console.WriteLine(unassignedEmployees.ToQueryString());
PrintEmployeeDetails(unassignedEmployees.ToList());

unassignedEmployees = QueryExecutor.GetUnassignedEmployeesAllQuerySyntax(context);
Console.WriteLine(unassignedEmployees.ToQueryString());
PrintEmployeeDetails(unassignedEmployees.ToList());


unassignedEmployees = QueryExecutor.GetUnassignedEmployeesAllMethodSyntax(context);
Console.WriteLine(unassignedEmployees.ToQueryString());
PrintEmployeeDetails(unassignedEmployees.ToList());

void PrintEmployeeDetails(List<Employee> employees)
{
    foreach (Employee employee in employees)
    {
        Console.WriteLine($"Name: {employee.Name}, Id: {employee.Id}");
    }
}
