using EntityFrameworkCoreVsDapper.Models;

namespace EntityFrameworkCoreVsDapper.Repositories
{
    public interface IPersonsRepository
    {
        public List<Person> Get_X_Persons(int personsNumber);
    }
}
