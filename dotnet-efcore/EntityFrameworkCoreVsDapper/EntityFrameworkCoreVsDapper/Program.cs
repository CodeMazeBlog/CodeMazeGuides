using BenchmarkDotNet.Running;
using EntityFrameworkCoreVsDapper.Repositories;

public class Program
{
    static void Main(string[] args)
    {
        var efCoreRepository = new PersonsRepositoryEFCore();
        efCoreRepository.GetXPersons(1000);

        var dapperRepository = new PersonsRepositoryDapper();
        dapperRepository.GetXPersons(1000);

        BenchmarkRunner.Run(typeof(Program).Assembly);
    } 
}