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
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByParams)]
    public class PersonsRepository : IDisposable
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
            _dbConnection.Open();

            return _dbConnection.Query<Person>($"SELECT TOP({personsNumber}) * FROM Persons").ToList();
        }

        [Benchmark]
        [Arguments(10000)]
        [Arguments(100000)]
        [Arguments(1000000)]
        public List<Person> GetXPersonsEFCore(int personsNumber)
        {
            return _context.Persons.Take(personsNumber).ToList();
        }

        [IterationCleanup]
        public void Cleanup()
        {
            Dispose();
        }

        public void Dispose()
        {
            _dbConnection.Close();
            _context.Dispose();
        }
    }
}
