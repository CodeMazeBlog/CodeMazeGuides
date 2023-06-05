using BenchmarkDotNet.Running;
using EntityFrameworkCoreVsDapper;
using EntityFrameworkCoreVsDapper.Repositories;

public class Program
{
    static void Main(string[] args)
    {
        BenchmarkRunner.Run(typeof(Program).Assembly);


        PersonsRepositoryEFCore EFCore_Repository = new PersonsRepositoryEFCore();
        EFCore_Repository.Get_1000_Persons();
        EFCore_Repository.Get_10000_Persons();
        EFCore_Repository.Get_100000_Persons();

        PersonsRepositoryDapper Dapper_Repository = new PersonsRepositoryDapper();
        Dapper_Repository.Get_1000_Persons();
        Dapper_Repository.Get_10000_Persons();
        Dapper_Repository.Get_100000_Persons();
    } 
}