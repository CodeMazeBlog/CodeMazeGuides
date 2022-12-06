using BenchmarkDotNet.Attributes;
using Bogus;
using DataTableToJsonTest;
using System.Data;
using BenchmarkDotNet.Jobs;

namespace DataTableToJsonTests
{
    [MemoryDiagnoser]
    [RankColumn, MeanColumn, MedianColumn]
    [HideColumns(new string[] { "Gen0","Gen1","Gen2","Job" })]
    [SimpleJob(RuntimeMoniker.Net60)]
    [SimpleJob(RuntimeMoniker.Net70)]
    public class Benchmark
    {
        public class Student
        {
            public string FirstName { get; set; } = string.Empty;
            public string LastName { get; set; } = string.Empty;
            public int BirthYear { get; set; }
        }

        private readonly Faker<Student> _faker = new Faker<Student>();
        private List<Student> students;
        private List<int> studentBirthYears;
        private const int count = 100000;

        public Benchmark()
        {
            students = _faker
                .RuleFor(m => m.FirstName, faker => faker.Person.FirstName)
                .RuleFor(m => m.LastName, faker => faker.Person.LastName)
                .RuleFor(m => m.BirthYear, faker => faker.Person.DateOfBirth.Year)
                .Generate(count);

            studentBirthYears = students.Select(m => m.BirthYear).ToList();
        }

        [Benchmark]
        public void Min() => studentBirthYears.Min();

        [Benchmark]
        public void List_Min() => students.Select(m => m.BirthYear).ToList().Min();

        //[Benchmark]
        //public void Max() => students.Max(m => m.BirthYear);

        //[Benchmark]
        //public void Sum() => students.Sum(m => m.BirthYear);

        //[Benchmark]
        //public void Average() => students.Average(m => m.BirthYear);


    }

}
