using BenchmarkDotNet.Attributes;
using Bogus;
using DataTableToJsonTest;
using System.Data;

namespace DataTableToJsonTests
{
    [MemoryDiagnoser]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class Benchmark
    {
        public class Student
        {
            public string FirstName { get; set; } = string.Empty;
            public string LastName { get; set; } = string.Empty;
            public int BirthYear { get; set; }
        }

        private readonly Faker<Student> _faker = new Faker<Student>();

        public DataTable dataTable;

        public Benchmark()
        {
            dataTable = GenerateDummyDataTable();
        }

        public DataTable GenerateDummyDataTable(int count = 1000)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("FirstName");
            dt.Columns.Add("LastName");
            dt.Columns.Add("BirthYear");

            foreach (var item in _faker
                .RuleFor(m => m.FirstName, faker => faker.Person.FirstName)
                .RuleFor(m => m.LastName, faker => faker.Person.LastName)
                .RuleFor(m => m.BirthYear, faker => faker.Person.DateOfBirth.Year)
                .Generate(count))
                dt.Rows.Add(new object[] { item.FirstName, item.LastName, item.BirthYear });
            
            return dt;
        }

        [Benchmark]
        public void NewtonsoftJsonNet() => Methods.DataTable_NewtonsoftJsonNet(dataTable);

        [Benchmark]
        public void SystemTextJson() => Methods.DataTable_SystemTextJson(dataTable);

        [Benchmark]
        public void Linq() => Methods.DataTable_Linq(dataTable);

        [Benchmark]
        public void StringBuilder() => Methods.DataTable_StringBuilder(dataTable);

    }

    public class Benchmark_10000 : Benchmark
    {
        public Benchmark_10000()
        {
            dataTable = GenerateDummyDataTable(10000);
        }
    }

    public class Benchmark_100000 : Benchmark
    {
        public Benchmark_100000()
        {
            dataTable = GenerateDummyDataTable(100000);
        }
    }

    public class Benchmark_1000000 : Benchmark
    {
        public Benchmark_1000000()
        {
            dataTable = GenerateDummyDataTable(1000000);
        }
    }
}
