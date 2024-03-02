using BenchmarkDotNet.Attributes;
using SelectWhereNotExistSqlQueryUsingLinq;

namespace SelectWhereNotExistSqlQueryUsingLinqBenchmark
{
    [MemoryDiagnoser(false)]
    public class QueryExucutorBenchmark
    {
        private EmployeeDbContext? _context;

        [GlobalSetup]
        public void Setup()
        {
            _context = new EmployeeDbContext();

            if (!_context.Database.CanConnect())
            {
                _context.Database.EnsureCreated();
                _context.AddSeedData();
            }
        }

        [Benchmark]
        public void GetUsingAnyWithQuerySyntax() => QueryExecutor.GetUnassignedEmployeesAnyQuerySyntax(_context!);

        [Benchmark]
        public void GetUsingAnyWithMethodSyntax() => QueryExecutor.GetUnassignedEmployeesAnyMethodSyntax(_context!);

        [Benchmark]
        public void GetUsingJoinWithQuerySyntax() => QueryExecutor.GetUnassignedEmployeesJoinQuerySyntax(_context!);

        [Benchmark]
        public void GetUsingJoinWithMethodSyntax() => QueryExecutor.GetUnassignedEmployeesJoinMethodSyntax(_context!);

        [Benchmark]
        public void GetUsingContainsWithQuerySyntax() => QueryExecutor.GetUnassignedEmployeesContainsQuerySyntax(_context!);

        [Benchmark]
        public void GetUsingContainsWithMethodSyntax() => QueryExecutor.GetUnassignedEmployeesContainsMethodSyntax(_context!);

        [Benchmark]
        public void GetUsingAllWithQuerySyntax() => QueryExecutor.GetUnassignedEmployeesAllQuerySyntax(_context!);

        [Benchmark]
        public void GetUsingAllWithMethodSyntax() => QueryExecutor.GetUnassignedEmployeesAllMethodSyntax(_context!);
    }
}
