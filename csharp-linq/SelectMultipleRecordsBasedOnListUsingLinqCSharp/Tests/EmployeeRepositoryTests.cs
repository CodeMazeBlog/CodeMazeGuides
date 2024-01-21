using SelectMultipleRecordsUsingLinqCSharp;

namespace Tests
{
    [TestClass]
    public class EmployeeRepositoryTests
    {
        [TestMethod]
        public void GivenTenUserInDb_WhenGetEmployeesUsingWhereWithList_ThenReturnsTenRecords()
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
        public void GivenTenUserInDb_WhenGetEmployeesUsingWhereWithHashSet_ThenReturnsTenRecords()
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
        public void GivenTenUserInDb_WhenGetEmployeesUsingJoinWithList_ThenReturnsTenRecords()
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
        public void GivenTenUserInDb_WhenGetEmployeesUsingJoinWithHasSet_ThenReturnsTenRecords()
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