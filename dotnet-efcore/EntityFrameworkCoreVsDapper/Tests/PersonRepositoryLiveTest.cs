using EntityFrameworkCoreVsDapper.Repositories;
using Assert = Xunit.Assert;

namespace Tests
{
    public class PersonRepositoryLiveTest
    {
        private PersonsRepository _repository = new PersonsRepository();

        [Fact]
        public void WhenQuerying1000ObjectsWithEFCore_ThenReturn1000Objects()
        {

            Assert.Equal(1000, _repository.GetXPersonsEFCore(1000).Count);
        }

        [Fact]
        public void WhenQuerying1000ObjectsWithDapper_ThenReturn1000Objects()
        {

            Assert.Equal(1000, _repository.GetXPersonsDapper(1000).Count);
        }

    }
}
