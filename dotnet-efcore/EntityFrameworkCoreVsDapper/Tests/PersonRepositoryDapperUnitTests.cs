using EntityFrameworkCoreVsDapper.Repositories;
using Assert = Xunit.Assert;

namespace Tests
{
    public class PersonRepositoryDapperUnitTests
    {
        private PersonsRepositoryDapper repository = new PersonsRepositoryDapper();

        [Fact]
        public void When_Quering1000Persons_ThenReturn1000Objects()
        {
            var queryResults = repository.Get_1000_Persons();

            Assert.True(1000 == queryResults.Count());
        }

        [Fact]
        public void When_Quering10000Persons_ThenReturn10000Objects()
        {
            var queryResults = repository.Get_10000_Persons();

            Assert.True(10000 == queryResults.Count());
        }

        [Fact]
        public void When_Quering10000Persons_ThenReturn100000Objects()
        {
            var queryResults = repository.Get_100000_Persons();

            Assert.True(100000 == queryResults.Count());
        }
    }
}
