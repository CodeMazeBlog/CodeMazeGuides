using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;

using EntityFrameworkCoreVsDapper.Repositories;

public class Program
{
    static void Main(string[] args)
    {
        var personsRepository = new PersonsRepository();
        personsRepository.GetXPersonsEFCore(1000);

        personsRepository.GetXPersonsDapper(1000);

        personsRepository.Dispose();

        BenchmarkRunner.Run<PersonsRepository>();
    }
}