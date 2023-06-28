using BenchmarkDotNet.Attributes;
using Dapper;
using EntityFrameworkCoreVsDapper.Models;
using System.Configuration;
using System.Data.SqlClient;

namespace EntityFrameworkCoreVsDapper.Repositories
{
    public class PersonsRepositoryDapper : IPersonsRepository
    {
        [Benchmark]
        [Arguments(1000)]
        [Arguments(10000)]
        [Arguments(100000)]
        public List<Person> GetXPersons(int personsNumber)
        {
            using var dbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["PersonsDB"].ConnectionString);

            dbConnection.Open();
            return dbConnection.Query<Person>($"SELECT TOP({personsNumber}) * FROM Persons").ToList();
        }
    }
}
