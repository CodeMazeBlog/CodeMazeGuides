using BenchmarkDotNet.Attributes;
using EntityFrameworkCoreVsDapper.EFCore;
using EntityFrameworkCoreVsDapper.Models;

namespace EntityFrameworkCoreVsDapper.Repositories
{
    public class PersonsRepositoryEFCore : IPersonsRepository
    {
        [Benchmark]
        public List<Person> Get_1000_Persons()
        {
            using (var db = new PersonsContext())
            {
                var items = db.Persons.Take(1000).ToList();

                return items;
            }
        }

        [Benchmark]
        public List<Person> Get_10000_Persons()
        {
            using (var db = new PersonsContext())
            {
                var items = db.Persons.Take(10000).ToList();

                return items;
            }
        }

        [Benchmark]
        public List<Person> Get_100000_Persons()
        {
            using (var db = new PersonsContext())
            {
                var items = db.Persons.Take(100000).ToList();

                return items;
            }
        }
    }
}
