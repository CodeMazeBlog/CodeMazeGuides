using Microsoft.EntityFrameworkCore;
using SelectWhereNotExistSqlQueryUsingLinq;

using var context = new EmployeeDbContext();

if (!context.Database.CanConnect())
{
   context.Database.EnsureCreated();
   context.AddSeedData();
}

var queryMethods = new Func<EmployeeDbContext, IQueryable<Employee>>[]
{
    QueryExecutor.GetUnassignedEmployeesAnyQuerySyntax,
    QueryExecutor.GetUnassignedEmployeesAnyMethodSyntax,
    QueryExecutor.GetUnassignedEmployeesJoinQuerySyntax,
    QueryExecutor.GetUnassignedEmployeesJoinMethodSyntax,
    QueryExecutor.GetUnassignedEmployeesContainsQuerySyntax,
    QueryExecutor.GetUnassignedEmployeesContainsMethodSyntax,
    QueryExecutor.GetUnassignedEmployeesAllQuerySyntax,
    QueryExecutor.GetUnassignedEmployeesAllMethodSyntax
};

foreach (var queryMethod in queryMethods)
{
    var unassignedEmployees = queryMethod(context);
    Console.WriteLine(unassignedEmployees.ToQueryString());
    PrintEmployeeDetails(unassignedEmployees.ToList());
    Console.WriteLine();
}

void PrintEmployeeDetails(List<Employee> employees)
{
    foreach (Employee employee in employees)
    {
        Console.WriteLine($"Name: {employee.Name}, Id: {employee.Id}");
    }
}
