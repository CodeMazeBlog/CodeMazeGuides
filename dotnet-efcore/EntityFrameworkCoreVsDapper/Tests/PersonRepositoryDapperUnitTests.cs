using EntityFrameworkCoreVsDapper.Repositories;
using Assert = Xunit.Assert;

namespace Tests
{
    public class PersonRepositoryDapperUnitTests
    {
        private PersonsRepositoryDapper repository = new PersonsRepositoryDapper();

        [Fact]
        public void When_Quering100Persons_ThenReturn100Persons()
        {
            var queryResults = repository.Get_X_Persons(100);

            Assert.Equal(100, queryResults.Count);
        }
    }
}
