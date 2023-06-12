using Microsoft.EntityFrameworkCore;

namespace DynamicQueriesInCSharp.Context
{
    public class ContextFactory
    {
        public ApplicationDbContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=test;Integrated Security=True")
                .Options;

            var context = new ApplicationDbContext(options);

            context.Database.EnsureCreated();

            return context;
        }
    }
}
