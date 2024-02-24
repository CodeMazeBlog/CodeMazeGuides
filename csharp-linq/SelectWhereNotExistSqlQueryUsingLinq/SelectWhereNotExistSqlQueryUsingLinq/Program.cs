using SelectWhereNotExistSqlQueryUsingLinq;

using var context = new EmployeeDbContext();

if (!context.Database.CanConnect())
{
   context.Database.EnsureCreated();
   context.AddSeedData();
}

PrintEmployeeDetails(QueryExecutor.GetUnassignedEmployeesUsingAnyWithQuerySyntax(context));

PrintEmployeeDetails(QueryExecutor.GetUnassignedEmployeesUsingAnyWithMethodSyntax(context));

PrintEmployeeDetails(QueryExecutor.GetUnassignedEmployeesUsingJoinWithQuerySyntax(context));

PrintEmployeeDetails(QueryExecutor.GetUnassignedEmployeesUsingJoinWithMethodSyntax(context));

PrintEmployeeDetails(QueryExecutor.GetUnassignedEmployeesUsingContainsWithQuerySyntax(context));

PrintEmployeeDetails(QueryExecutor.GetUnassignedEmployeesUsingContainsWithMethodSyntax(context));

PrintEmployeeDetails(QueryExecutor.GetUnassignedEmployeesUsingAllWithQuerySyntax(context));

PrintEmployeeDetails(QueryExecutor.GetUnassignedEmployeesUsingAllWithMethodSyntax(context));

void PrintEmployeeDetails(List<Employee> employees)
{
    foreach (Employee employee in employees)
    {
        Console.WriteLine($"Name: {employee.Name}, Id: {employee.Id}");
    }
}
