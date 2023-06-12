using EntityFrameworkCoreVsDapper.Models;

namespace EntityFrameworkCoreVsDapper.Repositories
{
    public interface IPersonsRepository
    {
        public List<Person> GetXPersons(int personsNumber);
    }
}
