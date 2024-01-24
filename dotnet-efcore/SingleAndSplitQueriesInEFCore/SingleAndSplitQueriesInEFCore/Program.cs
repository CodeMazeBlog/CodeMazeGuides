using BenchmarkDotNet.Running;
using Microsoft.EntityFrameworkCore;
using SingleAndSplitQueriesInEFCore;

await using var db = new CompaniesContext();
await db.Database.MigrateAsync();

BenchmarkRunner.Run<SingleAndSplitQueriesBenchmark>();
