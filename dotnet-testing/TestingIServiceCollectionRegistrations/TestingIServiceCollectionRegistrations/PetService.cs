namespace TestingIServiceCollectionRegistrations;

public interface IPetService
{
    void PrintName(string name);
}

public class PetService : IPetService
{
    public void PrintName(string name)
    {
        Console.WriteLine("The name of the pet is {0}", name);
    }
}