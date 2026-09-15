using Entities.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace AccountOwnerServer.Tests
{
    public class OwnerRepositoryTests(SqlServerFixture fixture) : IClassFixture<SqlServerFixture>
    {
        private readonly SqlServerFixture _fixture = fixture;

        [DockerFact]
        public async Task WhenGetAllOwnersAsyncIsCalled_ThenItReturnsTheSeededOwnersByName()
        {
            var repository = _fixture.CreateWrapper();

            var owners = (await repository.Owner.GetAllOwnersAsync()).ToList();

            Assert.Equal(4, owners.Count);
            Assert.Equal(["Anna Bosh", "John Keen", "Martin Miller", "Sam Query"], owners.Select(o => o.Name));
        }

        [DockerFact]
        public async Task WhenGetOwnerWithDetailsAsyncIsCalled_ThenItIncludesTheAccounts()
        {
            var repository = _fixture.CreateWrapper();
            var johnKeen = Guid.Parse("24fd81f8-d58a-4bcc-9f35-dc6cd5641906");

            var owner = await repository.Owner.GetOwnerWithDetailsAsync(johnKeen);

            Assert.NotNull(owner);
            Assert.Equal(3, owner.Accounts!.Count);
        }

        [DockerFact]
        public async Task WhenAnOwnerIsCreated_ThenSaveAsyncPersistsIt()
        {
            var repository = _fixture.CreateWrapper();
            var owner = new Owner
            {
                Id = Guid.NewGuid(),
                Name = "Ada Lovelace",
                DateOfBirth = new DateTime(1815, 12, 10),
                Address = "12 Analytical Engine Way"
            };

            repository.Owner.CreateOwner(owner);
            await repository.SaveAsync();

            var reloaded = await _fixture.CreateWrapper().Owner.GetOwnerByIdAsync(owner.Id);
            Assert.NotNull(reloaded);
            Assert.Equal("Ada Lovelace", reloaded.Name);

            // Leave the seeded data as we found it for the other tests.
            var cleanup = _fixture.CreateWrapper();
            var toDelete = await cleanup.Owner.GetOwnerByIdAsync(owner.Id);
            cleanup.Owner.DeleteOwner(toDelete!);
            await cleanup.SaveAsync();
        }

        [DockerFact]
        public async Task WhenAnOwnerWithAccountsIsDeleted_ThenTheForeignKeyRejectsIt()
        {
            var repository = _fixture.CreateWrapper();
            var johnKeen = Guid.Parse("24fd81f8-d58a-4bcc-9f35-dc6cd5641906");

            var owner = await repository.Owner.GetOwnerByIdAsync(johnKeen);
            repository.Owner.DeleteOwner(owner!);

            var exception = await Assert.ThrowsAsync<DbUpdateException>(repository.SaveAsync);

            var sqlException = Assert.IsType<SqlException>(exception.InnerException);
            Assert.Equal(547, sqlException.Number);
        }
    }
}
