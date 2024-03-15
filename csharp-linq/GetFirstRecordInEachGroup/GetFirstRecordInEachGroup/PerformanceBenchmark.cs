using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace GetFirstRecordInEachGroup;

[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[HideColumns(new string[] { "Job", "Error", "StdDev", "Median" })]
[MemoryDiagnoser(false)]
[RankColumn]
public class PerformanceBenchmark 
{
    private static readonly List<Student> _students = 
        Methods.GenerateStudents(1_000_000);

    [Benchmark]
    public List<Student> LinqGroupBy1() => 
        _students.GetYoungestStudentInClassLinqGroupBy1();

    [Benchmark]
    public List<Student> LinqGroupBy2() => 
        _students.GetYoungestStudentInClassLinqGroupBy2();

    [Benchmark]
    public List<Student> LinqLookup() =>
       _students.GetYoungestStudentInClassLinqLookup();

    [Benchmark]
    public List<Student> LinqDictionary() =>
       _students.GetYoungestStudentInClassLinqDictionary();

    [Benchmark]
    public List<Student> IterativeDictionary() => 
        _students.GetYoungestStudentInClassIterativeDictionary();
}