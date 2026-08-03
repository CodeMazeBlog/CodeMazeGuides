namespace TestingIServiceCollectionRegistrations;

public interface IMarineAnimalsService
{
    void PrintName(string name);
}

public class MarineAnimalsService : IMarineAnimalsService
{
    public void PrintName(string name)
    {
        Console.WriteLine("Marine animals like {0} lives in the ocean", name);
    }
}