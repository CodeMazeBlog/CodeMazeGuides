namespace SelectWhereNotExistSqlQueryUsingLinq
{
    public static class EmployeeDbContextExtension
    {
        public static void AddSeedData(this EmployeeDbContext context)
        {
            context.Employees.AddRange(
                new Employee { Id = 1, Name = "John" },
                new Employee { Id = 2, Name = "Alice" },
                new Employee { Id = 3, Name = "Bob" },
                new Employee { Id = 4, Name = "Eve" }
            );

            context.Tasks.AddRange(
                new EmployeeTask { TaskId = 101, EmployeeId = 1, Description = "Code Review" },
                new EmployeeTask { TaskId = 102, EmployeeId = 3, Description = "Testing" },
                new EmployeeTask { TaskId = 103, EmployeeId = 2, Description = "Documentation" }
            );

            context.SaveChanges();
        }
    }
}
