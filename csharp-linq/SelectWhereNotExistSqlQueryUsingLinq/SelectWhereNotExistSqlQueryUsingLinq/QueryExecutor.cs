using Microsoft.EntityFrameworkCore;

namespace SelectWhereNotExistSqlQueryUsingLinq
{
    public static class QueryExecutor
    {
        public static List<Employee> GetUnassignedEmployeesUsingAnyWithQuerySyntax(EmployeeDbContext context)
        {
            var employees = from employee in context.Employees
                                where !context.Tasks.Any(task => task.EmployeeId == employee.Id)
                            select employee;

            Console.WriteLine(employees.ToQueryString());

            return employees.ToList();
        }

        public static List<Employee> GetUnassignedEmployeesUsingAnyWithMethodSyntax(EmployeeDbContext context)
        {
            var employees = context.Employees
                .Where(employee => !context.Tasks.Any(task => task.EmployeeId == employee.Id));

            Console.WriteLine(employees.ToQueryString());

            return employees.ToList();
        }

        public static List<Employee> GetUnassignedEmployeesUsingJoinWithQuerySyntax(EmployeeDbContext context)
        {
            var employees = from employee in context.Employees
                                join task in context.Tasks on employee.Id equals task.EmployeeId into EmployeeTasks
                            from task in EmployeeTasks.DefaultIfEmpty()
                                 where task == null
                            select employee;

            Console.WriteLine(employees.ToQueryString());

            return employees.ToList();
        }

        public static List<Employee> GetUnassignedEmployeesUsingJoinWithMethodSyntax(EmployeeDbContext context)
        {
            var employees = context.Employees
                            .GroupJoin(context.Tasks, employee => employee.Id, task => task.EmployeeId, 
                            (employee, joinedRecords) => new { employee, joinedRecords })
                            .SelectMany(x => x.joinedRecords.DefaultIfEmpty(), (x, task) => new { x.employee, task })
                            .Where(x => x.task == null)
                            .Select(x => x.employee);


            Console.WriteLine(employees.ToQueryString());

            return employees.ToList();
        }

        public static List<Employee> GetUnassignedEmployeesUsingContainsWithQuerySyntax(EmployeeDbContext context)
        {
            var employees = from employee in context.Employees
                                where context.Tasks.All(task => task.EmployeeId != employee.Id)
                            select employee;

            Console.WriteLine(employees.ToQueryString());

            return employees.ToList();
        }

        public static List<Employee> GetUnassignedEmployeesUsingContainsWithMethodSyntax(EmployeeDbContext context)
        {
            var employees = context
                .Employees
                .Where(employee => !context.Tasks.Select(task => task.EmployeeId).Contains(employee.Id));

            Console.WriteLine(employees.ToQueryString());

            return employees.ToList();
        }

        public static List<Employee> GetUnassignedEmployeesUsingAllWithQuerySyntax(EmployeeDbContext context)
        {
            var employees = from employee in context.Employees
                                where context.Tasks.All(task => task.EmployeeId != employee.Id)
                            select employee;

            Console.WriteLine(employees.ToQueryString());

            return employees.ToList();
        }

        public static List<Employee> GetUnassignedEmployeesUsingAllWithMethodSyntax(EmployeeDbContext context)
        {
            var employees = context
                .Employees
                .Where(employee => context.Tasks.All(task => task.EmployeeId != employee.Id));

            Console.WriteLine(employees.ToQueryString());

            return employees.ToList();
        }
    }
}
