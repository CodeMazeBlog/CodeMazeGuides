using BenchmarkDotNet.Attributes;
using EntityFrameworkCoreVsDapper.EFCore;
using EntityFrameworkCoreVsDapper.Models;

namespace EntityFrameworkCoreVsDapper.Repositories
{
    public class PersonsRepositoryEFCore : IPersonsRepository
    {
        [Benchmark]
        [Arguments(1000)]
        [Arguments(10000)]
        [Arguments(100000)]
        public List<Person> Get_X_Persons(int personsNumber)
        {
            using var db = new PersonsContext();
            return db.Persons.Take(personsNumber).ToList();
        }
    }
}
