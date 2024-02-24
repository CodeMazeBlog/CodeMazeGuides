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
        public void GetUsingAnyWithQuerySyntax() => QueryExecutor.GetUnassignedEmployeesUsingAnyWithQuerySyntax(_context);

        [Benchmark]
        public void GetUsingAnyWithMethodSyntax() => QueryExecutor.GetUnassignedEmployeesUsingAnyWithMethodSyntax(_context);

        [Benchmark]
        public void GetUsingJoinWithQuerySyntax() => QueryExecutor.GetUnassignedEmployeesUsingJoinWithQuerySyntax(_context);

        [Benchmark]
        public void GetUsingJoinWithMethodSyntax() => QueryExecutor.GetUnassignedEmployeesUsingJoinWithMethodSyntax(_context);

        [Benchmark]
        public void GetUsingContainsWithQuerySyntax() => QueryExecutor.GetUnassignedEmployeesUsingContainsWithQuerySyntax(_context);

        [Benchmark]
        public void GetUsingContainsWithMethodSyntax() => QueryExecutor.GetUnassignedEmployeesUsingContainsWithMethodSyntax(_context);

        [Benchmark]
        public void GetUsingAllWithQuerySyntax() => QueryExecutor.GetUnassignedEmployeesUsingAllWithQuerySyntax(_context);

        [Benchmark]
        public void GetUsingAllWithMethodSyntax() => QueryExecutor.GetUnassignedEmployeesUsingAllWithMethodSyntax(_context);
    }
}
