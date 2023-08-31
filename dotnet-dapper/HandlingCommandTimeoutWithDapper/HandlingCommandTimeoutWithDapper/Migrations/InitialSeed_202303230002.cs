using FluentMigrator;
using HandlingCommandTimeoutWithDapper.Model;

namespace HandlingCommandTimeoutWithDapper.Migrations
{
    [Migration(202303230002)]
    public class InitialSeed_202303230002 : Migration
    {
        public override void Down()
        {
            Delete.FromTable("Employee")
                .Row(new Employee
                {
                    Id = new Guid("59c0d403-71ce-4ac8-9c2c-b0e54e7c043b"),
                    Age = 34,
                    Name = "Test Employee",
                    Position = "Test Position",
                    CompanyId = new Guid("67fbac34-1ee1-4697-b916-1748861dd275")
                });

            Delete.FromTable("Company")
                .Row(new Company
                {
                    Id = new Guid("330f9f7b-9ffd-48a0-8eae-416cd2b26702"),
                    Address = "Test Address 1",
                    Country = "Spain",
                    Name = "Test Name 1",
                });

            Delete.FromTable("Company")
                .Row(new Company
                {
                    Id = new Guid("67fbac34-1ee1-4697-b916-1748861dd275"),
                    Address = "Test Address",
                    Country = "USA",
                    Name = "Test Name"
                });
        }

        public override void Up()
        {
            Insert.IntoTable("Company")
                .Row(new Company
                {
                    Id = new Guid("330f9f7b-9ffd-48a0-8eae-416cd2b26702"),
                    Address = "Test Address 1",
                    Country = "Spain",
                    Name = "Test Name 1",
                });

            Insert.IntoTable("Company")
                .Row(new Company
                {
                    Id = new Guid("67fbac34-1ee1-4697-b916-1748861dd275"),
                    Address = "Test Address 2",
                    Country = "USA",
                    Name = "Test Name 2",
                });

            Insert.IntoTable("Employee")
                .Row(new Employee
                {
                    Id = new Guid("59c0d403-71ce-4ac8-9c2c-b0e54e7c043b"),
                    Age = 34,
                    Name = "Test Employee",
                    Position = "Test Position",
                    CompanyId = new Guid("67fbac34-1ee1-4697-b916-1748861dd275"),
                });
        }
    }
}
