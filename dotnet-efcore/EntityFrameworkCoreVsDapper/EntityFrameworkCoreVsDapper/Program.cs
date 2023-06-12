using BenchmarkDotNet.Running;
using EntityFrameworkCoreVsDapper.Repositories;

public class Program
{
    static void Main(string[] args)
    {
        PersonsRepositoryEFCore EFCoreRepository = new PersonsRepositoryEFCore();
        EFCoreRepository.GetXPersons(1000);

        PersonsRepositoryDapper DapperRepository = new PersonsRepositoryDapper();
        DapperRepository.GetXPersons(1000);

        BenchmarkRunner.Run(typeof(Program).Assembly);
    } 
}