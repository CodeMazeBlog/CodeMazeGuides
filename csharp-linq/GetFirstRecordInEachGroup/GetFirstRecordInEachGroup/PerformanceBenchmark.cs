using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace GetFirstRecordInEachGroup;

[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[HideColumns(new string[] { "Job", "Error", "StdDev", "Median" })]
[MemoryDiagnoser(false)]
[RankColumn]
public class PerformanceBenchmark 
{
    private static readonly List<Student> students = 
        Methods.GenerateStudents();

    [Benchmark]
    public List<Student> LinqGroupBy1() => 
        students.GetYoungestStudentInClassLinqGroupBy1();

    [Benchmark]
    public List<Student> LinqGroupBy2() => 
        students.GetYoungestStudentInClassLinqGroupBy2();

    [Benchmark]
    public List<Student> LinqLookup() =>
       students.GetYoungestStudentInClassLinqLookup();

    [Benchmark]
    public List<Student> LinqDictionary() =>
       students.GetYoungestStudentInClassLinqDictionary();

    [Benchmark]
    public List<Student> IterativeDictionary() => 
        students.GetYoungestStudentInClassIterativeDictionary();
}