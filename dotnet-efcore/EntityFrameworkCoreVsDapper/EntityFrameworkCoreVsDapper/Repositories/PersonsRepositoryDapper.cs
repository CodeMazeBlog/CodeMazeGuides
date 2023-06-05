using BenchmarkDotNet.Attributes;
using Dapper;
using EntityFrameworkCoreVsDapper.Models;
using System.Data.SqlClient;

namespace EntityFrameworkCoreVsDapper.Repositories
{
    public class PersonsRepositoryDapper : IPersonsRepository
    {
        //ADD THE CONNECTION STRING TO YOUR DATABASE HERE
        private string ConnectionString = "Data Source=DESKTOP-VM6E980;User ID=sa;Password=P@ssw0rd;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;Database=EntityFrameworkVsDapperDB";

        [Benchmark]
        public List<Person> Get_1000_Persons()
        {
            using (var dbConnection = new SqlConnection(ConnectionString))
            {
                dbConnection.Open();
                List<Person> items = (List<Person>)dbConnection.Query<Person>("SELECT TOP(1000) * FROM Persons");
                dbConnection.Close();

                return items;
            }
        }

        [Benchmark]
        public List<Person> Get_10000_Persons()
        {
            using (var dbConnection = new SqlConnection(ConnectionString))
            {
                dbConnection.Open();
                List<Person> items = (List<Person>)dbConnection.Query<Person>("SELECT TOP(10000) * FROM Persons");
                dbConnection.Close();

                return items;
            }
        }

        [Benchmark]
        public List<Person> Get_100000_Persons()
        {
            using (var dbConnection = new SqlConnection(ConnectionString))
            {
                dbConnection.Open();
                List<Person> items = (List<Person>)dbConnection.Query<Person>("SELECT TOP(100000) * FROM Persons");
                dbConnection.Close();

                return items;
            }
        }
    }
}
