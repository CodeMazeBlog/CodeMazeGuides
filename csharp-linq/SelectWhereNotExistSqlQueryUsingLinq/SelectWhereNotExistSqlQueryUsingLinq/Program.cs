using SelectWhereNotExistSqlQueryUsingLinq;

using var context = new EmployeeDbContext();

if (!context.Database.CanConnect())
{
   context.Database.EnsureCreated();
   context.AddSeedData();
}

PrintEmployeeDetails(QueryExecutor.GetUnassignedEmployeesAnyQuerySyntax(context));

PrintEmployeeDetails(QueryExecutor.GetUnassignedEmployeesAnyMethodSyntax(context));

PrintEmployeeDetails(QueryExecutor.GetUnassignedEmployeesJoinQuerySyntax(context));

PrintEmployeeDetails(QueryExecutor.GetUnassignedEmployeesJoinMethodSyntax(context));

PrintEmployeeDetails(QueryExecutor.GetUnassignedEmployeesContainsQuerySyntax(context));

PrintEmployeeDetails(QueryExecutor.GetUnassignedEmployeesContainsMethodSyntax(context));

PrintEmployeeDetails(QueryExecutor.GetUnassignedEmployeesAllQuerySyntax(context));

PrintEmployeeDetails(QueryExecutor.GetUnassignedEmployeesAllMethodSyntax(context));

void PrintEmployeeDetails(List<Employee> employees)
{
    foreach (Employee employee in employees)
    {
        Console.WriteLine($"Name: {employee.Name}, Id: {employee.Id}");
    }
}
