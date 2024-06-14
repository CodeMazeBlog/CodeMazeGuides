namespace TestingIServiceCollectionRegistrations;

public class WildAnimalServices : IAnimalService
{
    public void PrintName(string name)
    {
        Console.WriteLine("Wild animals like {0} are not domesticated", name);
    }
}