using EntityFrameworkCoreVsDapper.Repositories;
using System.Configuration;
using Assert = Xunit.Assert;

namespace Tests
{
    public class PersonRepositoryDapperLiveTest
    {
        private PersonsRepositoryDapper repository = new PersonsRepositoryDapper();

        [Fact]
        public void WhenQuerying100Persons_ThenReturnListHas100Persons()
        {
            var queryResults = repository.GetXPersons(100);

            Assert.Equal(100, queryResults.Count);
        }
    }
}
