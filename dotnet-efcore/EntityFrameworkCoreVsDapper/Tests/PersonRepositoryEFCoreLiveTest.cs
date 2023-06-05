using EntityFrameworkCoreVsDapper.Repositories;
using Assert = Xunit.Assert;

namespace Tests
{
    public class PersonRepositoryEFCoreLiveTest
    {
        private PersonsRepositoryEFCore repository = new PersonsRepositoryEFCore();

        [Fact]
        public void WhenQuering100Persons_ThenReturnListHas100Objects()
        {
            var queryResults = repository.Get_X_Persons(100);

            Assert.Equal(100, queryResults.Count);
        }

    }
}
