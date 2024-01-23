namespace SelectMultipleRecordsUsingLinqCSharp;

public static class CompanyDbContextExtensions
{
    public static void AddSeedData(this CompanyDbContext dbContext, int recordCount)
    {
        for (var cnt = 1; cnt <= recordCount; cnt++)
        {
            var employee = new Employee
            {
                Id = cnt,
                Name = $"Name {cnt}",
            };

            dbContext.Employees.Add(employee);
        }

        dbContext.SaveChanges();
    }
}
