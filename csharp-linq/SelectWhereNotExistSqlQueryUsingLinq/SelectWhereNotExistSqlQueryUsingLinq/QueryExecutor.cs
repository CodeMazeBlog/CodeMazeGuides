namespace SelectWhereNotExistSqlQueryUsingLinq
{
    public static class QueryExecutor
    {
        public static IQueryable<Employee> GetUnassignedEmployeesAnyQuerySyntax(EmployeeDbContext context)
        {
            var employees =
                from employee in context.Employees
                where !context.Tasks.Any(task => task.EmployeeId == employee.Id)
                select employee;

            return employees;
        }

        public static IQueryable<Employee> GetUnassignedEmployeesAnyMethodSyntax(EmployeeDbContext context)
        {
            var employees = context.Employees
                .Where(employee => !context.Tasks
                    .Any(task => task.EmployeeId == employee.Id));

            return employees;
        }

        public static IQueryable<Employee> GetUnassignedEmployeesJoinQuerySyntax(EmployeeDbContext context)
        {
            var employees =
                from employee in context.Employees
                join task in context.Tasks on
                employee.Id equals task.EmployeeId
                into EmployeeTasks
                from task in EmployeeTasks.DefaultIfEmpty()
                where task == null
                select employee;

            return employees;
        }

        public static IQueryable<Employee> GetUnassignedEmployeesJoinMethodSyntax(EmployeeDbContext context)
        {
            var employees = context.Employees.GroupJoin(
                context.Tasks, 
                employee => employee.Id, 
                task => task.EmployeeId, 
                (employee, joinedRecords) => new { employee, joinedRecords })
                .SelectMany(x => x.joinedRecords.DefaultIfEmpty(),
                (x, task) => new { x.employee, task })
                .Where(x => x.task == null)
                .Select(x => x.employee);

            return employees;
        }

        public static IQueryable<Employee> GetUnassignedEmployeesContainsQuerySyntax(EmployeeDbContext context)
        {
            var employees =
                from employee in context.Employees
                where context.Tasks.All(task => task.EmployeeId != employee.Id)
                select employee;

            return employees;
        }

        public static IQueryable<Employee> GetUnassignedEmployeesContainsMethodSyntax(EmployeeDbContext context)
        {
            var employees = context
                .Employees
                .Where(employee => !context
                    .Tasks
                    .Select(task => task.EmployeeId)
                    .Contains(employee.Id));

            return employees;
        }

        public static IQueryable<Employee> GetUnassignedEmployeesAllQuerySyntax(EmployeeDbContext context)
        {
            var employees =
                from employee in context.Employees
                where context.Tasks.All(task =>task.EmployeeId != employee.Id)
                select employee;

            return employees;
        }

        public static IQueryable<Employee> GetUnassignedEmployeesAllMethodSyntax(EmployeeDbContext context)
        {
            var employees = context
                .Employees
                .Where(employee => context.Tasks
                    .All(task => task.EmployeeId != employee.Id));

            return employees;
        }
    }
}
