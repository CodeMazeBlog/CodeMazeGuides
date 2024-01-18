using BenchmarkDotNet.Running;
using Microsoft.EntityFrameworkCore;
using SingleAndSplitQueriesInEFCore;

await using var db = new CompaniesContext();
await db.Database.MigrateAsync();


//await db.Companies
//    .Include(company => company.Products)
//    .Include(company => company.Departments)
//    .ThenInclude(department => department.Employees)
//    .AsSingleQuery()
//    .ToListAsync();

//await db.Companies
//    .Include(company => company.Products)
//    .Include(company => company.Departments)
//    .ThenInclude(department => department.Employees)
//    .AsSplitQuery()
//    .ToListAsync();

BenchmarkRunner.Run<SingleAndSplitBenchmark>();
