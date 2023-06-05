using BenchmarkDotNet.Running;
using EntityFrameworkCoreVsDapper.Repositories;

public class Program
{
    static void Main(string[] args)
    {
        BenchmarkRunner.Run(typeof(Program).Assembly);


        PersonsRepositoryEFCore EFCore_Repository = new PersonsRepositoryEFCore();
        EFCore_Repository.Get_X_Persons(1000);

        PersonsRepositoryDapper Dapper_Repository = new PersonsRepositoryDapper();
        Dapper_Repository.Get_X_Persons(1000);
    } 
}