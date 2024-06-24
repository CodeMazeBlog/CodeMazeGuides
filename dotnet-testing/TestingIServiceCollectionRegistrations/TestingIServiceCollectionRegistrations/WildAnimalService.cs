namespace TestingIServiceCollectionRegistrations;

public interface IWildAnimalService
{
    void PrintName(string name);
}

public class WildAnimalService : IWildAnimalService
{
    public void PrintName(string name)
    {
        Console.WriteLine("Wild animals like {0} are not domesticated", name);
    }
}