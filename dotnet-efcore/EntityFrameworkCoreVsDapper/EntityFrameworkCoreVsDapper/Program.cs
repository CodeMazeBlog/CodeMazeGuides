using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using EntityFrameworkCoreVsDapper.Repositories;

public class Program
{
    static void Main(string[] args)
    {
        var PersonsRepository = new PersonsRepository();
        PersonsRepository.GetXPersonsEFCore(1000);

        PersonsRepository.GetXPersonsDapper(1000);

        BenchmarkRunner.Run(typeof(Program).Assembly);
    } 
}