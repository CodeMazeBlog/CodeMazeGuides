using BenchmarkDotNet.Attributes;
using EntityFrameworkCoreVsDapper.EFCore;
using EntityFrameworkCoreVsDapper.Models;
using System.Configuration;

namespace EntityFrameworkCoreVsDapper.Repositories
{
    public class PersonsRepositoryEFCore : IPersonsRepository
    {
        [Benchmark]
        [Arguments(1000)]
        [Arguments(10000)]
        [Arguments(100000)]
        public List<Person> GetXPersons(int personsNumber)
        {
            using var db = new PersonsContext();
            return db.Persons.Take(personsNumber).ToList();
        }
    }
}
