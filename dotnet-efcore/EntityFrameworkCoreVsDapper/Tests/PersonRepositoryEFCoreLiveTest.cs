using EntityFrameworkCoreVsDapper.Repositories;
using Assert = Xunit.Assert;

namespace Tests
{
    public class PersonRepositoryEFCoreLiveTest
    {
        private PersonsRepositoryEFCore repository = new PersonsRepositoryEFCore();

        [Fact]
        public void WhenQuerying100Persons_ThenReturnListHas100Persons()
        {
            var queryResults = repository.GetXPersons(100);

            Assert.Equal(100, queryResults.Count);
        }

    }
}
