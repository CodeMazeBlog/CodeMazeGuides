using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using Dapper;
using EntityFrameworkCoreVsDapper.EFCore;
using EntityFrameworkCoreVsDapper.Models;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;

namespace EntityFrameworkCoreVsDapper.Repositories
{
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByMethod)]
    public class PersonsRepository
    {
        private SqlConnection _dbConnection;
        private PersonsContext _context;

        public PersonsRepository() 
        {
            Setup();
        }

        [IterationSetup]
        public void Setup()
        {
            _dbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["PersonsDB"].ConnectionString);
            _context = new PersonsContext();
        }

        [Benchmark]
        [Arguments(10000)]
        [Arguments(100000)]
        [Arguments(1000000)]
        public List<Person> GetXPersonsDapper(int personsNumber)
        {
            using (_dbConnection)
            {
                _dbConnection.Open();

                return _dbConnection.Query<Person>($"SELECT TOP({personsNumber}) * FROM Persons").ToList();
            }
        }

        [Benchmark]
        [Arguments(10000)]
        [Arguments(100000)]
        [Arguments(1000000)]
        public List<Person> GetXPersonsEFCore(int personsNumber)
        {
            using (_context)
            {
                return _context.Persons.Take(personsNumber).ToList();
            }  
        }
    }
}
