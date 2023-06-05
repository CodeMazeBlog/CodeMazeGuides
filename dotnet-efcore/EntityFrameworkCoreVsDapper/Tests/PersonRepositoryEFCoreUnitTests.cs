using EntityFrameworkCoreVsDapper.Repositories;
using Assert = Xunit.Assert;

namespace Tests
{
    public class PersonRepositoryEFCoreUnitTests
    {
        private PersonsRepositoryEFCore repository = new PersonsRepositoryEFCore();

        [Fact]
        public void When_Quering100Persons_ThenReturn100Persons()
        {
            var queryResults = repository.Get_X_Persons(100);

            Assert.Equal(100, queryResults.Count);
        }

    }
}
