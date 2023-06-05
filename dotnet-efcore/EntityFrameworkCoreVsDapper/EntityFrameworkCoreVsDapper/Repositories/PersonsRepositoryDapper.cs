using BenchmarkDotNet.Attributes;
using Dapper;
using EntityFrameworkCoreVsDapper.Models;
using System.Data.SqlClient;

namespace EntityFrameworkCoreVsDapper.Repositories
{
    public class PersonsRepositoryDapper : IPersonsRepository
    {
        //ADD THE CONNECTION STRING TO YOUR DATABASE HERE
        private string ConnectionString = "";

        [Benchmark]
        [Arguments(1000)]
        [Arguments(10000)]
        [Arguments(100000)]
        public List<Person> Get_X_Persons(int personsNumber)
        {
            using var dbConnection = new SqlConnection(ConnectionString);

            dbConnection.Open();
            return dbConnection.Query<Person>($"SELECT TOP({personsNumber}) * FROM Persons").ToList();
        }
    }
}
