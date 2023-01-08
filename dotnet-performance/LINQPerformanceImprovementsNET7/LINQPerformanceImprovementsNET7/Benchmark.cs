using BenchmarkDotNet.Attributes;
using Bogus;
using System.Data;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Configs;

namespace LINQPerformanceImprovementsNET7
{
    [RankColumn]
    [HideColumns(new string[] { "Job", "Error", "StdDev", "Median" })]
    [MemoryDiagnoser(false)]
    [SimpleJob(RuntimeMoniker.Net60)]
    [SimpleJob(RuntimeMoniker.Net70)]
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByMethod)]
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
        private List<Student> students2;
        private List<int> studentBirthYears;
        private List<int> studentBirthYears2;
        private const int count = 100000;

        public Benchmark()
        {
            students = _faker
                .RuleFor(m => m.FirstName, faker => faker.Person.FirstName)
                .RuleFor(m => m.LastName, faker => faker.Person.LastName)
                .RuleFor(m => m.BirthYear, faker => faker.Person.DateOfBirth.Year)
                .Generate(count);
            students2 = students.ToList();

            studentBirthYears = students.Select(m => m.BirthYear).ToList();
            studentBirthYears2 = studentBirthYears.ToList();
        }

        [Benchmark]
        public void Min() => studentBirthYears.Min();

        [Benchmark]
        public void Max() => studentBirthYears.Max();

        [Benchmark]
        public void Average() => studentBirthYears.Average();

        [Benchmark]
        public void Sum() => studentBirthYears.Sum();

        [Benchmark]
        public void Count() => studentBirthYears.Sum();

        [Benchmark]
        public void First() => studentBirthYears.First();

        [Benchmark]
        public void Last() => studentBirthYears.Last();

        [Benchmark]
        public void Distinct() => studentBirthYears.Distinct();

        [Benchmark]
        public void Where() => studentBirthYears.Where(m => m > 1980);

        [Benchmark]
        public void Group() => studentBirthYears.GroupBy(m => m);

        [Benchmark]
        public void Join() => studentBirthYears.Join(studentBirthYears2, m => m, k => k, (m, k) => m);

        [Benchmark]
        public void List_Min() => students.Min(m => m.BirthYear);

        [Benchmark]
        public void List_Max() => students.Max(m => m.BirthYear);

        [Benchmark]
        public void List_Average() => students.Average(m => m.BirthYear);

        [Benchmark]
        public void List_Sum() => students.Sum(m => m.BirthYear);

        [Benchmark]
        public void List_Count() => students.Count();

        [Benchmark]
        public void List_First() => students.First();

        [Benchmark]
        public void List_Last() => students.Last();

        [Benchmark]
        public void List_Distinct() => students.Distinct();

        [Benchmark]
        public void List_Where() => students.Where(m => m.BirthYear > 1980);

        [Benchmark]
        public void List_Group() => students.GroupBy(m => m.BirthYear);

        [Benchmark]
        public void List_Join() => students.Join(students2, m => m.BirthYear, k => k.BirthYear, (m, k) => m);
    }
}
