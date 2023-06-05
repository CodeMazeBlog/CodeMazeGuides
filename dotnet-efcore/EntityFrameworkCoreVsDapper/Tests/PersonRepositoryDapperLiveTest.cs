using EntityFrameworkCoreVsDapper.Repositories;
using Assert = Xunit.Assert;

namespace Tests
{
    public class PersonRepositoryDapperLiveTest
    {
        private PersonsRepositoryDapper repository = new PersonsRepositoryDapper();

        [Fact]
        public void WhenQuering100Persons_ThenReturnListHas100Objects()
        {
            var queryResults = repository.Get_X_Persons(100);

            Assert.Equal(100, queryResults.Count);
        }
    }
}
