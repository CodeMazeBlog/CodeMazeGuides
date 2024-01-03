using SelectMultipleRecordsUsingLinqCSharp;

namespace Tests
{
    [TestClass]
    public class EmployeeRepositoryTests
    {
        [TestMethod]
        public void WhenGetEmployeesUsingWhereWithList_ReturnsRecords()
        {
            var dbContext = new CompanyDbContext();
            dbContext.Database.EnsureCreated();
            dbContext.AddSeedData(10);

            var repository = new EmployeeRepository(dbContext);
            
            var result = repository.GetEmployeesUsingWhere(Enumerable.Range(1, 10).ToList());
            dbContext.Database.EnsureDeleted();

            Assert.IsTrue(result.Count == 10);
        }

        [TestMethod]
        public void WhenGetEmployeesUsingWhereWithHashSet_ReturnsRecords()
        {
            var dbContext = new CompanyDbContext();
            dbContext.Database.EnsureCreated();
            dbContext.AddSeedData(10);

            var repository = new EmployeeRepository(dbContext);

            var result = repository.GetEmployeesUsingWhere(Enumerable.Range(1, 10).ToHashSet());
            dbContext.Database.EnsureDeleted();

            Assert.IsTrue(result.Count == 10);
        }

        [TestMethod]
        public void WhenGetEmployeesUsingJoinWithList_ReturnsRecords()
        {
            var dbContext = new CompanyDbContext();
            dbContext.Database.EnsureCreated();
            dbContext.AddSeedData(10);

            var repository = new EmployeeRepository(dbContext);

            var result = repository.GetEmployeesUsingJoin(Enumerable.Range(1, 10).ToList());
            dbContext.Database.EnsureDeleted();

            Assert.IsTrue(result.Count == 10);
        }

        [TestMethod]
        public void WhenGetEmployeesUsingJoinWithHasSet_ReturnsRecords()
        {
            var dbContext = new CompanyDbContext();
            dbContext.Database.EnsureCreated();
            dbContext.AddSeedData(10);

            var repository = new EmployeeRepository(dbContext);

            var result = repository.GetEmployeesUsingJoin(Enumerable.Range(1, 10).ToHashSet());
            dbContext.Database.EnsureDeleted();

            Assert.IsTrue(result.Count == 10);
        }
    }
}